using JD.MyFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace MyFiles
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
            uint trackNr;
            foreach (var xitem in listView1.Items)
            {
                var item = (ListViewItem)xitem;
                var file = Path.Combine(comboBox1.Text, item.Text);
                try
                {
                    var song = TagLib.File.Create(file, ReadStyle.PictureLazy);
                    var s = Path.GetFileNameWithoutExtension(file);
                    var ss = s.Split('-');
                    if (uint.TryParse(ss[0].Trim(), out trackNr)) song.Tag.Track = trackNr;
                    if (radioButton1.Checked) ss[1] = ZH.ToSimplified(ss[1]);
                    if (radioButton2.Checked) ss[1] = ZH.ToTraditional(ss[1]);
                    song.Tag.Title = ss[1].Trim();
                    song.Save();
                    Application.DoEvents();
                }
                catch (Exception ex) { item.Remove(); }
            }
            Cursor = Cursors.Default;
        }
    }
}
