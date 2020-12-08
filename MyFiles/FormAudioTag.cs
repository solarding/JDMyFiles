using JD.MF;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TagLib;

namespace JD
{
    public partial class Form1 : Form
    {       
        public Form1()
        {
            InitializeComponent();
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
            var option = cbSizeOption.Text.ToUpper();
            float newSizeOption;
            if (option.EndsWith("GB"))
                newSizeOption = 1024 * 1024 * 1024f;
            else if (option.EndsWith("MB"))
                newSizeOption = 1024 * 1024f;
            else if (option.EndsWith("KB"))
                newSizeOption = 1024f;
            else
                newSizeOption = 1;
            if (Math.Abs(newSizeOption - _sizeOption)<0.001) return;
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

        private void ReloadFiles()
        {
            bool readTag = chkMedia.Checked;

            Cursor = Cursors.WaitCursor;
            if (readTag) GenerateColumns(true);
            lv.Items.Clear();
            lv.BeginUpdate();
            var files = new DirectoryInfo(comboBox1.Text).GetFiles();
            foreach (var file in files)
            {
                var item = lv.Items.Add(file.Name, string.IsNullOrEmpty(file.Extension) ? "" : file.Extension.Substring(1).ToLower());
                item.SubItems.Add((file.Length/_sizeOption).ToString("#,#.###"));
                if (!readTag)  continue;  
                
                try
                {
                    var song = TagLib.File.Create(file.FullName, ReadStyle.PictureLazy);                    
                    item.SubItems.Add(song.Tag.Title);
                    item.SubItems.Add(song.Tag.AlbumArtists.FirstOrDefault()??song.Tag.FirstPerformer);
                }
                catch { }
            }
            lv.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            ReloadFiles();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            foreach (var xitem in lv.Items)
            {
                var item = (ListViewItem)xitem;
                var file = Path.Combine(comboBox1.Text, item.Text);
                try
                {
                    var song = TagLib.File.Create(file, ReadStyle.PictureLazy);
                    var s = Path.GetFileNameWithoutExtension(file);
                    AudioTagUtil.ParseFilename(s, song.Tag);                   
                    song.Save();                   
                }
                catch (Exception ex) { item.Remove(); }
            }
            Cursor = Cursors.Default;
        }

        private void bntFormatFN_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            foreach (var xitem in lv.Items)
            {
                var item = (ListViewItem)xitem;
                var file = Path.Combine(comboBox1.Text, item.Text);
                try
                {
                    var song = TagLib.File.Create(file, ReadStyle.PictureLazy);
                    if (string.IsNullOrEmpty(song.Tag.Title)) continue;
                    var s = Path.GetFileNameWithoutExtension(file);
                    var newFN = file.Replace(s, (song.Tag.FirstPerformer ?? song.Tag.FirstAlbumArtist) + " - " + song.Tag.Title);
                    System.IO.File.Move(file, newFN);
                   
                }
                catch (Exception ex) { item.Remove(); }
            }
            Cursor = Cursors.Default;

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

            using (var formPlayer = new FormPlayer(filename))
            {
                formPlayer.StartPosition = FormStartPosition.CenterParent;               
                formPlayer.ShowDialog(this);
            }

        }


    }
}
