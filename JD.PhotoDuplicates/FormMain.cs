using CoenM.ImageHash.HashAlgorithms;
using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CoenM.ImageHash;
using CoenM.ImageHash.HashAlgorithms;
using System.Drawing;
using System.Collections.Concurrent;

namespace JD.PhotoDuplicates
{
    public partial class FormMain : Form
    {       
        public FormMain()
        {
            InitializeComponent();
            cbSizeOption.SelectedIndex = 1;
            comboBox1.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            GenerateColumns(false);
        }

        private void GenerateColumns(bool isMedia = false)
        {
            lv.Clear();
            lv.Columns.Add("File Name", 350);
            lv.Columns.Add("Size(K)", 80, HorizontalAlignment.Right);
            if (!isMedia) return;

            lv.Columns.Add("Title", 300);
            lv.Columns.Add("Artist", 150);
        }

        private void btnLookupFolder_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 5) folderBrowserDialog1.SelectedPath = comboBox1.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            comboBox1.Text = folderBrowserDialog1.SelectedPath;
            comboBox1.Items.Add(comboBox1.Text);
            ReloadFiles();
        }

        private float _sizeOption = 1024.0f;
        private void cbSizeOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            var option = cbSizeOption.Text.ToUpper()[^2..];
            float newSizeOption;
            if (option == "GB")
                newSizeOption = 1024 * 1024 * 1024f;
            else if (option == "MB")
                newSizeOption = 1024 * 1024f;
            else if (option.EndsWith("KB"))
                newSizeOption = 1024f;
            else
                newSizeOption = 1;
            if (Math.Abs(newSizeOption - _sizeOption) < 0.001) return;
            _sizeOption = newSizeOption;
            lv.Columns[1].Text = $"Size({option})";
            ReloadFiles();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadFiles();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ReloadFiles();
        }


        private readonly string[] folders = [@"D:\Photos\DCIM D", @"D:\Photos\Photos from 2013", @"D:\Photos\Photos from 2014"];
        private readonly Dictionary<ulong, List<string>> hashToFiles = [];
        private void Log(string msg) { lv.Items.Add(msg + Environment.NewLine); }

        private void ReloadFiles()
        {
            bool readTag = chkMedia.Checked;
            var location = comboBox1.Text;
            if (readTag) GenerateColumns(true);
            lv.Items.Clear();
            
            try
            {
                var directoryInfo = new DirectoryInfo(location);
                var phasher = new PerceptualHash();
                var hashToFiles = new ConcurrentDictionary<ulong, List<string>>(); // Thread-safe

                var allFiles = folders
                    .Where(Directory.Exists)
                    .SelectMany(f => Directory.EnumerateFiles(f, "*.*", SearchOption.AllDirectories))
                    .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Parallel.ForEach(allFiles, file =>
                {
                    try
                    {
                        using var img = SixLabors.ImageSharp.Image.Load<SixLabors.ImageSharp.PixelFormats.Rgba32>(file);
                        ulong hash = phasher.Hash(img);
                        hashToFiles.AddOrUpdate(hash, [file],
                            (_, list) => { lock (list) list.Add(file); return list; });
                    }
                    catch (Exception ex)
                    {
                        Invoke(() => Log($"Error processing {file}: {ex.Message}"));
                    }
                    //lblInfo.Text = $"Processing[{hashToFiles.Count}]: {file}"; Application.DoEvents();
                });

                // Process and handle duplicates
                foreach (var pair in hashToFiles.Where(kvp => kvp.Value.Count > 1))
                {
                    var duplicates = pair.Value;
                    var tempFiles = duplicates.Where(f => f.Contains("FolderTemp", StringComparison.OrdinalIgnoreCase)).ToList();
                    var others = duplicates.Except(tempFiles).ToList();

                    if (tempFiles.Any())
                    {
                        foreach (var tempFile in tempFiles)
                        {
                            Log($"Duplicate found in Temp: {tempFile}");
                            try
                            {
                                File.Delete(tempFile);
                                Log($"Deleted: {tempFile}");
                            }
                            catch (Exception ex)
                            {
                                Log($"Failed to delete {tempFile}: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        Log($"Duplicate set (no Temp):\n  - {string.Join("\n  - ", duplicates)}");
                    }
                }

                Log("Done scanning.");
            }
            catch (DirectoryNotFoundException)
            {
                if (location.Contains("\\")) //try devices
                {
                    //var locations = location.Split("\\");
                    //var devices = MediaDevice.GetDevices();
                    //using var device = devices.FirstOrDefault(d => d.FriendlyName == locations[1]);
                    //if (device != null)
                    //{
                    //    device.Connect();
                    //    var dir = device.GetDirectoryInfo(string.Join('\\', locations[2..])); //\Phone\Music
                    //    var files = dir.EnumerateFiles("*.*", SearchOption.AllDirectories);
                    //    foreach (var file in files)
                    //    {
                    //        var item = lv.Items.Add(file.Name);
                    //        item.SubItems.Add((file.Length / _sizeOption).ToString("#,#.##"));
                    //        if (!readTag) continue;

                    //        try
                    //        {
                                
                    //        }
                    //        catch { }
                    //    }
                    //    device.Disconnect();
                    //}
                }
            }
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            ReloadFiles();
        }        
        
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var filename = Path.Combine(comboBox1.Text, lv.SelectedItems[0].Text);
            //if it is directory,go into
            if (Directory.Exists(filename))
            {
                comboBox1.Text = filename;
                ReloadFiles();
                return;
            }

            using var formPlayer = new FormPlayer(filename);
            formPlayer.StartPosition = FormStartPosition.CenterParent;
            formPlayer.ShowDialog(this);

        }      
     
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedIndices.Count == 0) return;
            txtReplaceOld.Text = lv.SelectedItems[0].Text;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
