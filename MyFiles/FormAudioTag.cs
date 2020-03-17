using JD.MF;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TagLib;

namespace JD
{
    public partial class Form1 : Form
    {
        private NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
        readonly IntPtr hSysImgList;
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));           
            
            NativeMethods.SetWindowTheme(listView1.Handle, "Explorer", null);

            //set Icons library 
            hSysImgList = NativeMethods.SHGetFileInfo("", 0, ref shfi, (uint)Marshal.SizeOf(shfi), NativeMethods.SHGFI_SYSICONINDEX | NativeMethods.SHGFI_SMALLICON);

            // Set the ListView control to use that image list.
            IntPtr hOldImgList = NativeMethods.SendMessage(listView1.Handle, NativeMethods.LVM_SETIMAGELIST, NativeMethods.LVSIL_SMALL, hSysImgList);

            // If the ListView control already had an image list, delete the old one.
            if (hOldImgList != IntPtr.Zero)
            {
                NativeMethods.ImageList_Destroy(hOldImgList);
            }
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
            // Get the items from the file system, and add each of them to the ListView,
            // complete with their corresponding name and icon indices.
            string[] s = Directory.GetFileSystemEntries(comboBox1.Text);
            foreach (string file in s)
            {
                IntPtr himl = NativeMethods.SHGetFileInfo(file, 0, ref shfi, (uint)Marshal.SizeOf(shfi),
                                                NativeMethods.SHGFI_DISPLAYNAME | NativeMethods.SHGFI_SYSICONINDEX | NativeMethods.SHGFI_SMALLICON);
                if (himl != hSysImgList)
                {
                    // MessageBox.Show("WTF? " + file);
                    listView1.Items.Add(Path.GetFileName(file), 0);
                }
                else
                {
                    var item = listView1.Items.Add(shfi.szDisplayName, shfi.iIcon);   
                    if (readTag)
                    {
                        try
                        {
                            var song = TagLib.File.Create(file, ReadStyle.PictureLazy);
                            item.SubItems.Add(song.Tag.Title);
                            item.SubItems.Add(song.Tag.AlbumArtists.FirstOrDefault());                            
                        }
                        catch { }
                    }
                }
            }
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
                    Application.DoEvents();
                }
                catch (Exception ex) { item.Remove(); }
            }
            Cursor = Cursors.Default;
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
