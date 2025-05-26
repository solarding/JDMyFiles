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
            btnTags = new Button();
            btnFix = new Button();
            btnFormatFN = new Button();
            chkMedia = new CheckBox();
            cbSizeOption = new ComboBox();
            groupBox1 = new GroupBox();
            chk2SimplifiedChinese = new CheckBox();
            chkChineseNumber = new CheckBox();
            label1 = new Label();
            btnDoRename = new Button();
            txtReplaceNew = new TextBox();
            txtReplaceOld = new TextBox();
            lblVersion = new Label();
            btnLookUpFolder = new Button();
            lblInfo = new Label();
            groupBox1.SuspendLayout();
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
            lv.Location = new Point(0, 105);
            lv.Margin = new Padding(3, 4, 3, 4);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.ShowGroups = false;
            lv.Size = new Size(959, 438);
            lv.TabIndex = 1;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.ItemActivate += listView1_ItemActivate;
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
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.KeyDown += comboBox1_KeyDown;
            // 
            // btnTags
            // 
            btnTags.Location = new Point(401, 11);
            btnTags.Name = "btnTags";
            btnTags.Size = new Size(72, 27);
            btnTags.TabIndex = 4;
            btnTags.Text = "Scan";
            btnTags.UseVisualStyleBackColor = true;
            btnTags.Click += btnTags_Click;
            // 
            // btnFix
            // 
            btnFix.Location = new Point(144, 45);
            btnFix.Name = "btnFix";
            btnFix.Size = new Size(108, 26);
            btnFix.TabIndex = 8;
            btnFix.Text = "Guess Tag";
            btnFix.UseVisualStyleBackColor = true;
            // 
            // btnFormatFN
            // 
            btnFormatFN.Location = new Point(14, 45);
            btnFormatFN.Name = "btnFormatFN";
            btnFormatFN.Size = new Size(124, 27);
            btnFormatFN.TabIndex = 9;
            btnFormatFN.Text = "Format file name";
            btnFormatFN.UseVisualStyleBackColor = true;
            // 
            // chkMedia
            // 
            chkMedia.AutoSize = true;
            chkMedia.Location = new Point(274, 49);
            chkMedia.Name = "chkMedia";
            chkMedia.Size = new Size(93, 21);
            chkMedia.TabIndex = 10;
            chkMedia.Text = "Media Files";
            chkMedia.UseVisualStyleBackColor = true;
            // 
            // cbSizeOption
            // 
            cbSizeOption.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbSizeOption.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbSizeOption.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSizeOption.FormattingEnabled = true;
            cbSizeOption.Items.AddRange(new object[] { " B", "in KB", "in MB", "in GB" });
            cbSizeOption.Location = new Point(401, 49);
            cbSizeOption.Name = "cbSizeOption";
            cbSizeOption.Size = new Size(72, 25);
            cbSizeOption.TabIndex = 11;
            cbSizeOption.SelectedIndexChanged += cbSizeOption_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chk2SimplifiedChinese);
            groupBox1.Controls.Add(chkChineseNumber);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDoRename);
            groupBox1.Controls.Add(txtReplaceNew);
            groupBox1.Controls.Add(txtReplaceOld);
            groupBox1.Location = new Point(496, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(428, 94);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "manipulate name";
            // 
            // chk2SimplifiedChinese
            // 
            chk2SimplifiedChinese.AutoSize = true;
            chk2SimplifiedChinese.Location = new Point(6, 56);
            chk2SimplifiedChinese.Name = "chk2SimplifiedChinese";
            chk2SimplifiedChinese.Size = new Size(63, 21);
            chk2SimplifiedChinese.TabIndex = 6;
            chk2SimplifiedChinese.Text = "转简体";
            chk2SimplifiedChinese.UseVisualStyleBackColor = true;
            // 
            // chkChineseNumber
            // 
            chkChineseNumber.AutoSize = true;
            chkChineseNumber.Location = new Point(163, 56);
            chkChineseNumber.Name = "chkChineseNumber";
            chkChineseNumber.Size = new Size(122, 21);
            chkChineseNumber.TabIndex = 5;
            chkChineseNumber.Text = "中文🡆阿拉伯数字";
            chkChineseNumber.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 28);
            label1.Name = "label1";
            label1.Size = new Size(19, 17);
            label1.TabIndex = 3;
            label1.Text = "🡆";
            // 
            // btnDoRename
            // 
            btnDoRename.Location = new Point(336, 22);
            btnDoRename.Name = "btnDoRename";
            btnDoRename.Size = new Size(77, 55);
            btnDoRename.TabIndex = 2;
            btnDoRename.Text = "Rename GO!";
            btnDoRename.UseVisualStyleBackColor = true;
            // 
            // txtReplaceNew
            // 
            txtReplaceNew.Location = new Point(163, 25);
            txtReplaceNew.Name = "txtReplaceNew";
            txtReplaceNew.Size = new Size(120, 23);
            txtReplaceNew.TabIndex = 1;
            // 
            // txtReplaceOld
            // 
            txtReplaceOld.Location = new Point(6, 25);
            txtReplaceOld.Name = "txtReplaceOld";
            txtReplaceOld.Size = new Size(128, 23);
            txtReplaceOld.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(16, 82);
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
            btnLookUpFolder.Size = new Size(26, 27);
            btnLookUpFolder.TabIndex = 14;
            btnLookUpFolder.UseVisualStyleBackColor = false;
            btnLookUpFolder.Click += btnLookupFolder_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.Location = new Point(144, 82);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(16, 16);
            lblInfo.TabIndex = 15;
            lblInfo.Text = "...";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 543);
            Controls.Add(lblInfo);
            Controls.Add(btnLookUpFolder);
            Controls.Add(lblVersion);
            Controls.Add(groupBox1);
            Controls.Add(cbSizeOption);
            Controls.Add(chkMedia);
            Controls.Add(btnFormatFN);
            Controls.Add(btnFix);
            Controls.Add(btnTags);
            Controls.Add(comboBox1);
            Controls.Add(lv);
            Font = new Font("Microsoft YaHei", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            Text = "Audio Tag";
            Load += OnFormLoad;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnLookupFolder;
        private System.Windows.Forms.Button btnTags;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnFormatFN;
        private System.Windows.Forms.CheckBox chkMedia;
        private System.Windows.Forms.ComboBox cbSizeOption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReplaceNew;
        private System.Windows.Forms.TextBox txtReplaceOld;
        private System.Windows.Forms.Button btnDoRename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox chkChineseNumber;
        private System.Windows.Forms.CheckBox chk2SimplifiedChinese;
        private System.Windows.Forms.Label lblVersion;
        private Button btnLookUpFolder;
        private Label lblInfo;
    }
}

