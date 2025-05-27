using CoenM.ImageHash.HashAlgorithms;
using System.Collections.Concurrent;
using System.Globalization;
using System.Threading;

namespace JD.PhotoDuplicates
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            comboBox1.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            GenerateColumns(false);
        }

        private CancellationTokenSource cancellationTokenSource;

        private void GenerateColumns(bool isMedia = false)
        {
            lv.Clear();
            lv.Columns.Add("info1", 350);
            lv.Columns.Add("Info2", 80, HorizontalAlignment.Right);
            lv.Columns.Add("info3", 80);
            lv.Columns.Add("info4", 80);
        }

        private void btnLookupFolder_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 5) folderBrowserDialog1.SelectedPath = comboBox1.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            comboBox1.Text = folderBrowserDialog1.SelectedPath;
            comboBox1.Items.Add(comboBox1.Text);
        }

        private readonly string[] folders = [@"D:\Photos\DCIM D", @"D:\Photos\Photos from 2013", @"D:\Photos\Photos from 2014"];
        ConcurrentDictionary<ulong, List<string>> hashToFiles = []; // Thread-safe

        private void ReloadFiles(CancellationToken token, string? location = null)
        {
            hashToFiles.Clear();
            try
            {
                var phasher = new PerceptualHash();               

                var allFiles = folders
                    .Where(Directory.Exists)
                    .SelectMany(f => Directory.EnumerateFiles(f, "*.*", SearchOption.AllDirectories))
                    .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    .ToList();
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    CancellationToken = token
                };

                DateTime lastUpdate = DateTime.MinValue;
                Parallel.ForEach(allFiles, options, file =>
                {
                    token.ThrowIfCancellationRequested(); // check for cancellation

                    try
                    {
                        using var img = SixLabors.ImageSharp.Image.Load<SixLabors.ImageSharp.PixelFormats.Rgba32>(file);
                        ulong hash = phasher.Hash(img);
                        hashToFiles.AddOrUpdate(hash, [file],
                            (_, list) => { lock (list) list.Add(file); return list; });
                    }
                    catch (Exception ex)
                    {
                        Invoke(() => lblInfo.Text = $"Error processing {file}: {ex.Message}");
                    }
                    // Throttle UI updates to once every 100ms
                    if ((DateTime.Now - lastUpdate).TotalMilliseconds > 100)
                    {
                        lastUpdate = DateTime.Now;
                        Invoke(() =>
                        {
                            lblInfo.Text = $"Processing[{hashToFiles.Count}]: {file}";
                        });
                    }
                });

                // Process and handle duplicates
                foreach (var pair in hashToFiles.Where(kvp => kvp.Value.Count > 1))
                {
                    Invoke(() =>
                    {
                        var item = lv.Items.Add($"{pair.Key:X16}");
                        item.SubItems.Add($"{pair.Value.Count} duplicates)");
                        var duplicates = pair.Value;
                        var tempFiles = duplicates.Where(f => f.Contains(folders[0][5..], StringComparison.OrdinalIgnoreCase)).ToList();
                        var others = duplicates.Except(tempFiles).ToList();

                        if (tempFiles.Any())
                        {
                            foreach (var tempFile in tempFiles)
                            {                                
                                try
                                {
                                    // File.Delete(tempFile);
                                    item.SubItems.Add($"Deleted: {tempFile}");
                                }
                                catch (Exception ex)
                                {
                                    lblInfo.Text = $"Failed to delete {tempFile}: {ex.Message}";
                                }
                            }
                        }
                        else
                        {
                            item.SubItems.Add($"Duplicate set (no Temp):\n  - {string.Join("\n  - ", duplicates)}");
                        }
                    });
                }                
            }
            catch (OperationCanceledException ex)
            {
                return; // Handle cancellation gracefully
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

        private async void btnScan_Click(object sender, EventArgs e)
        {
            btnScan.Enabled = false;
            lblInfo.Text = "Starting scan...";

            var location = comboBox1.Text;
            GenerateColumns(true);
            lv.Items.Clear();

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            await Task.Run(() => ReloadFiles(token, location));

            lblInfo.Text = "Scan complete.";
            btnScan.Enabled = true;
        }


        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0) return;
            var currentItem = lv.SelectedItems[0];
            var selectedHash = currentItem.Text;
            if (ulong.TryParse(selectedHash, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var hash))
            {
                if (hashToFiles.TryGetValue(hash, out var filePaths) && filePaths.Count > 1)
                {
                    var previewForm = new ImageView(filePaths);
                    previewForm.ShowDialog(); // or .Show() for non-blocking
                }
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
