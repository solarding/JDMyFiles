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
        }

        private void GenerateColumns(bool reset = false)
        {
            if (reset)
            {
                listView1.Clear();
                listView1.Columns.Add("File Name", 350);
            }
            listView1.Columns.Add("Title", 300);
            listView1.Columns.Add("Artist", 150);

        }

        private void btnLookupFolder_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 5) folderBrowserDialog1.SelectedPath = comboBox1.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            comboBox1.Text = folderBrowserDialog1.SelectedPath;
            comboBox1.Items.Add(comboBox1.Text);
            LoadDir(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadDir();
        }

        private void LoadDir(bool readTag = false)
        {
            Cursor = Cursors.WaitCursor;
            if (readTag) GenerateColumns(true);
            listView1.Items.Clear();
            listView1.BeginUpdate();
            var files = new DirectoryInfo(comboBox1.Text).GetFiles();
            foreach (var file in files)
            {
                var item = listView1.Items.Add(file.Name, file.Extension.Substring(1).ToLower());
                if (!readTag)  continue;  
                
                try
                {
                    var song = TagLib.File.Create(file.FullName, ReadStyle.PictureLazy);                    
                    item.SubItems.Add(song.Tag.Title);
                    item.SubItems.Add(song.Tag.AlbumArtists.FirstOrDefault()??song.Tag.FirstPerformer);
                }
                catch { }
            }
            listView1.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            LoadDir(true);
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            foreach (var xitem in listView1.Items)
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

            foreach (var xitem in listView1.Items)
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

            LoadDir(true);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var filename = Path.Combine(comboBox1.Text, listView1.SelectedItems[0].Text);
            //if it is directory,go into
            if (Directory.Exists(filename))
            {
                comboBox1.Text = filename;
                LoadDir(true);
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
