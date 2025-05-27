
namespace JD.PhotoDuplicates
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            ListViewItem listViewItem5 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            folderBrowserDialog1 = new FolderBrowserDialog();
            lv = new ListView();
            ColumnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            comboBox1 = new ComboBox();
            btnScan = new Button();
            lblVersion = new Label();
            btnLookUpFolder = new Button();
            lblInfo = new Label();
            btnStop = new Button();
            SuspendLayout();
            // 
            // lv
            // 
            lv.Activation = ItemActivation.TwoClick;
            lv.AllowColumnReorder = true;
            lv.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, columnHeader2 });
            lv.Dock = DockStyle.Bottom;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5 });
            lv.LabelEdit = true;
            lv.Location = new Point(0, 75);
            lv.Margin = new Padding(3, 4, 3, 4);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.ShowGroups = false;
            lv.Size = new Size(959, 468);
            lv.TabIndex = 1;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Name = "ColumnHeader1";
            ColumnHeader1.Text = "Name";
            ColumnHeader1.Width = 265;
            // 
            // columnHeader2
            // 
            columnHeader2.Name = "columnHeader2";
            columnHeader2.Text = "Size";
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "D:\\Photos" });
            comboBox1.Location = new Point(14, 13);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(349, 25);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "C:\\";
            // 
            // btnScan
            // 
            btnScan.Location = new Point(401, 11);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(72, 27);
            btnScan.TabIndex = 4;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(14, 42);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(42, 17);
            lblVersion.TabIndex = 13;
            lblVersion.Text = "lblVer";
            // 
            // btnLookUpFolder
            // 
            btnLookUpFolder.BackColor = SystemColors.ButtonHighlight;
            btnLookUpFolder.Image = (Image)resources.GetObject("btnLookUpFolder.Image");
            btnLookUpFolder.Location = new Point(369, 11);
            btnLookUpFolder.Margin = new Padding(3, 4, 3, 4);
            btnLookUpFolder.Name = "btnLookUpFolder";
            btnLookUpFolder.Size = new Size(26, 26);
            btnLookUpFolder.TabIndex = 14;
            btnLookUpFolder.UseVisualStyleBackColor = false;
            btnLookUpFolder.Click += btnLookupFolder_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.Location = new Point(142, 42);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(16, 16);
            lblInfo.TabIndex = 15;
            lblInfo.Text = "...";
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.Stop_16x;
            btnStop.Location = new Point(479, 12);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(26, 26);
            btnStop.TabIndex = 16;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 543);
            Controls.Add(btnStop);
            Controls.Add(lblInfo);
            Controls.Add(btnLookUpFolder);
            Controls.Add(lblVersion);
            Controls.Add(btnScan);
            Controls.Add(comboBox1);
            Controls.Add(lv);
            Font = new Font("Microsoft YaHei", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            Text = "Hunting Duplicate Photos";
            Load += OnFormLoad;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnLookupFolder;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblVersion;
        private Button btnLookUpFolder;
        private Label lblInfo;
        private Button btnStop;
    }
}

