﻿using CoenM.ImageHash.HashAlgorithms;
using JD.PhotoDuplicates.Gui;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace JD.PhotoDuplicates
{
    public partial class FormMainDuplicate : Form
    {
        private CancellationTokenSource? cancellationTokenSource;
        private readonly ConcurrentDictionary<ulong, List<FileInfo>> _hashT = []; // Thread-safe
        private readonly Dictionary<ulong, string> keepList = [];

        public FormMainDuplicate()
        {
            InitializeComponent();
            comboBox1.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
        }

        private void btnLookupFolder_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 5) folderBrowserDialog1.SelectedPath = comboBox1.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            comboBox1.Text = folderBrowserDialog1.SelectedPath;
            comboBox1.Items.Add(comboBox1.Text);
        }

        private void ScanForDuplicates(ConcurrentDictionary<ulong, List<FileInfo>>  dict, FileInfo[] allFiles, IProgress<(int, string)> progress, CancellationToken token)
        {   
            var phasher = new PerceptualHash();
            int processedCount = 0;

            try
            {
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = (int)(Environment.ProcessorCount * 0.85),
                    CancellationToken = token
                };

                DateTime lastUpdate = DateTime.MinValue;
                Parallel.ForEach(allFiles, options, file =>
                {
                    token.ThrowIfCancellationRequested(); // check for cancellation

                    try
                    {
                        using var img = SixLabors.ImageSharp.Image.Load<SixLabors.ImageSharp.PixelFormats.Rgba32>(file.FullName);
                        ulong hash = phasher.Hash(img);

                        dict.AddOrUpdate(hash, [file], (_, list) =>
                            {
                                lock (list)
                                    if (!list.Any(f => f.FullName == file.FullName)) list.Add(file);
                                return list;
                            });

                        //report progress to UI
                        int current = Interlocked.Increment(ref processedCount);
                        if ((DateTime.Now - lastUpdate).TotalMilliseconds > 200)
                        {
                            lastUpdate = DateTime.Now;
                            progress.Report((current, $"Processing [{dict.Count}]: {file}"));
                        }
                    }
                    catch (Exception ex)
                    {
                        Invoke(() => lblInfo.Text = $"Error processing {file}: {ex.Message}");
                    }
                });

                Invoke(PostProcessFindings);
            }
            catch (OperationCanceledException) { return; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void PostProcessFindings()
        {
            var rootPath = comboBox1.Text.Length;
            var dispensableFolder = "DCIM"; //TODO in 1.1, make a customizable list of choices. maybe through drag and drop
            keepList.Clear();

            lv.BeginUpdate();
            // Process and handle duplicates
            foreach (var pair in _hashT.Where(kvp => kvp.Value.Count > 1))
            {
                //check again, fl might be deleted somewhere else
                for (int i = 0; i < pair.Value.Count; i++) { if (pair.Value[i].Exists == false) pair.Value.RemoveAt(i); }

                var item = lv.Items.Add($"{pair.Key:X16}");
                item.SubItems.Add($"{pair.Value.Count} duplicates)");
                var duplicates = pair.Value;

                //get the best to keep
                var keep = duplicates.OrderByDescending(f => f.Length).ThenBy(f => f.Name.Length).First();
                var restOfDups = duplicates.Except([keep]).ToList();
                if (keep.FullName.Contains(dispensableFolder))
                {
                    keep = restOfDups.FirstOrDefault(f => f.Length >= keep.Length && f.Name.Length <= keep.Length && !f.FullName.Contains(dispensableFolder)) ?? keep;
                    restOfDups = duplicates.Except([keep]).ToList();
                }
                item.SubItems.Add($"{keep.FullName[rootPath..]} ({keep.Length / 1024f / 1024f:#.##}MB)");
                keepList.Add(pair.Key, keep.FullName);

                for (int i = 0; i < restOfDups.Count; i++)
                {
                    if (i < 2) item.SubItems.Add($"{restOfDups[i].FullName[rootPath..]} ({restOfDups[i].Length / 1024f / 1024f:#.##}MB)");
                    else { item.SubItems.AddRange(restOfDups.Skip(2).Select(f => f.FullName[..rootPath]).ToArray()); }
                }
            }
            lv.EndUpdate();
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            var location = comboBox1.Text;
            lv.Items.Clear();
            btnScan.Enabled = false;
            lblInfo.Text = "Starting scan...";
            btnStop.Visible = true;
            try
            {
                var dir = new DirectoryInfo(location);
                var allFiles = dir.EnumerateFiles("*.*", SearchOption.AllDirectories)
                        .Where(f => f.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                    f.Name.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                    f.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                int totalFiles = allFiles.Length;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = totalFiles;
                progressBar1.Value = 0;

                var progress = new Progress<(int count, string info)>(
                    update =>
                    {
                        progressBar1.Value = update.count;
                        //lblProgress.Text = $"{update.count} / {totalFiles}";
                        lblInfo.Text = update.info;
                    });
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                if (!_hashT.IsEmpty)
                {
                    var result = MessageBox.Show("Do you want to clear the previous findings?", "Clear Findings",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        _hashT.Clear();
                        lblInfo.Text = "Previous findings cleared. Starting new scan...";
                    }
                    else if (result == DialogResult.No)
                    {
                        // Create a HashSet of full paths for fast lookups
                        var existingFilePaths = new HashSet<string>(
                            _hashT.Values.SelectMany(fl => fl.Select(f => f.FullName)), StringComparer.OrdinalIgnoreCase);
                        var filteredFiles = allFiles.Where(f => !existingFilePaths.Contains(f.FullName));
                        allFiles = [.. filteredFiles];
                        lblInfo.Text = $"Continuing with previous findings. (excluded {existingFilePaths.Count} files)";

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        btnScan.Enabled = true;
                        btnStop.Visible = false;
                        return; // User cancelled the operation
                    }
                }

                await Task.Run(() => ScanForDuplicates(_hashT, allFiles, progress, token), token);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            lblInfo.Text = "Scan complete.";
            btnScan.Enabled = true;
            btnStop.Visible = false;
        }


        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0) return;
            var currentItem = lv.SelectedItems[0];
            var selectedHash = currentItem.Text;
            if (ulong.TryParse(selectedHash, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var hash))
            {
                if (_hashT.TryGetValue(hash, out var filePaths) && filePaths.Count > 1)
                {
                    var previewForm = new ImageView(filePaths);
                    previewForm.ShowDialog(); // or .Show() for non-blocking
                }
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void FormMainDuplicate_Resize(object sender, EventArgs e)
        {
            lv.Height = this.Height - panel1.Height - 50;
        }

        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var column = this.lv.Columns[e.Column];
            column.Tag ??= true;
            bool asc = (bool)column.Tag;
            this.lv.ListViewItemSorter = new ListViewColumnSorter(e.Column, asc);
            this.lv.Sort();
            column.Tag = !asc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lv.Items.Clear();
            PostProcessFindings();
        }

        private void btnDelDuplicate_Click(object sender, EventArgs e)
        {
            foreach (var keep in keepList)
            {
                var dupliates = _hashT[keep.Key] ?? throw new Exception($"The to be kept file for {keep.Key} is missing!");
                foreach (var dup in dupliates.Where(f => f.FullName != keep.Value))
                {
                    try
                    {
                        if (File.Exists(dup.FullName)) dup.Delete(); lblInfo.Text = $"deleted: {dup.FullName}";
                    }
                    catch (Exception ex)
                    {
                        lblInfo.Text = $"Error deleting {dup.FullName}: {ex.Message}";
                    }
                    finally { Application.DoEvents(); }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FileName = "imageHashes.json",
                DefaultExt = "json"
            };
            var rst = saveFileDialog1.ShowDialog(this);
            if (rst != DialogResult.OK) return;
            DictionaryStorage.SaveToJson(_hashT, saveFileDialog1.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                FileName = "imageHashes.json",
                DefaultExt = "json"
            };
            var rst = openFileDialog1.ShowDialog(this);
            if (rst != DialogResult.OK) return;
            _hashT.Clear();
            var loadedData = DictionaryStorage.LoadFromJson(openFileDialog1.FileName);
            foreach (var kvp in loadedData)
            {
                _hashT.TryAdd(kvp.Key, kvp.Value);
            }
        }
    }
}
