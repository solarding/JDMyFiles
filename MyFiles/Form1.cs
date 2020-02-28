using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            listView1.Columns.Add("Name", 600);
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

        private void btnLookupFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            comboBox1.Text = folderBrowserDialog1.SelectedPath;
            comboBox1.Items.Add(comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDir();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadDir();
        }

        private void LoadDir()
        {
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
                { listView1.Items.Add(shfi.szDisplayName, shfi.iIcon); }
            }
        }

    }
}
