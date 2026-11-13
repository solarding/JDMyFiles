namespace JD
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            lv = new System.Windows.Forms.ListView();
            ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            comboBox1 = new System.Windows.Forms.ComboBox();
            btnLookupFolder = new System.Windows.Forms.Button();
            btnTags = new System.Windows.Forms.Button();
            btnFix = new System.Windows.Forms.Button();
            btnFormatFN = new System.Windows.Forms.Button();
            chkMedia = new System.Windows.Forms.CheckBox();
            cbSizeOption = new System.Windows.Forms.ComboBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            chkOverwrite = new System.Windows.Forms.CheckBox();
            chk2SimplifiedChinese = new System.Windows.Forms.CheckBox();
            chkChineseNumber = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            btnDoRename = new System.Windows.Forms.Button();
            txtReplaceNew = new System.Windows.Forms.TextBox();
            txtReplaceOld = new System.Windows.Forms.TextBox();
            lblVersion = new System.Windows.Forms.Label();
            chkDir = new System.Windows.Forms.CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lv
            // 
            lv.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            lv.AllowColumnReorder = true;
            lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ColumnHeader1, columnHeader2 });
            lv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lv.Items.AddRange(new System.Windows.Forms.ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5 });
            lv.LabelEdit = true;
            lv.Location = new System.Drawing.Point(0, 137);
            lv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.ShowGroups = false;
            lv.Size = new System.Drawing.Size(1135, 404);
            lv.TabIndex = 1;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = System.Windows.Forms.View.Details;
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
            comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(13, 11);
            comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(329, 29);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "C:\\";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.KeyDown += comboBox1_KeyDown;
            // 
            // btnLookupFolder
            // 
            btnLookupFolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            btnLookupFolder.Image = (System.Drawing.Image)resources.GetObject("btnLookupFolder.Image");
            btnLookupFolder.Location = new System.Drawing.Point(348, 9);
            btnLookupFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLookupFolder.Name = "btnLookupFolder";
            btnLookupFolder.Size = new System.Drawing.Size(32, 31);
            btnLookupFolder.TabIndex = 3;
            btnLookupFolder.UseVisualStyleBackColor = false;
            btnLookupFolder.Click += btnLookupFolder_Click;
            // 
            // btnTags
            // 
            btnTags.Location = new System.Drawing.Point(386, 9);
            btnTags.Name = "btnTags";
            btnTags.Size = new System.Drawing.Size(75, 31);
            btnTags.TabIndex = 4;
            btnTags.Text = "Scan";
            btnTags.UseVisualStyleBackColor = true;
            btnTags.Click += btnTags_Click;
            // 
            // btnFix
            // 
            btnFix.Location = new System.Drawing.Point(135, 44);
            btnFix.Name = "btnFix";
            btnFix.Size = new System.Drawing.Size(110, 35);
            btnFix.TabIndex = 8;
            btnFix.Text = "Guess Tag";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += btnFix_Click;
            // 
            // btnFormatFN
            // 
            btnFormatFN.Location = new System.Drawing.Point(13, 44);
            btnFormatFN.Name = "btnFormatFN";
            btnFormatFN.Size = new System.Drawing.Size(120, 35);
            btnFormatFN.TabIndex = 9;
            btnFormatFN.Text = "Format file name";
            btnFormatFN.UseVisualStyleBackColor = true;
            btnFormatFN.Click += bntFormatFN_Click;
            // 
            // chkMedia
            // 
            chkMedia.AutoSize = true;
            chkMedia.Location = new System.Drawing.Point(258, 50);
            chkMedia.Name = "chkMedia";
            chkMedia.Size = new System.Drawing.Size(122, 25);
            chkMedia.TabIndex = 10;
            chkMedia.Text = "Media Files";
            chkMedia.UseVisualStyleBackColor = true;
            // 
            // cbSizeOption
            // 
            cbSizeOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            cbSizeOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cbSizeOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSizeOption.FormattingEnabled = true;
            cbSizeOption.Items.AddRange(new object[] { " B", "in KB", "in MB", "in GB" });
            cbSizeOption.Location = new System.Drawing.Point(467, 9);
            cbSizeOption.Name = "cbSizeOption";
            cbSizeOption.Size = new System.Drawing.Size(80, 29);
            cbSizeOption.TabIndex = 11;
            cbSizeOption.SelectedIndexChanged += cbSizeOption_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkOverwrite);
            groupBox1.Controls.Add(chk2SimplifiedChinese);
            groupBox1.Controls.Add(chkChineseNumber);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDoRename);
            groupBox1.Controls.Add(txtReplaceNew);
            groupBox1.Controls.Add(txtReplaceOld);
            groupBox1.Location = new System.Drawing.Point(654, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(481, 88);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "manipulate name";
            // 
            // chkOverwrite
            // 
            chkOverwrite.AutoSize = true;
            chkOverwrite.Location = new System.Drawing.Point(225, 54);
            chkOverwrite.Name = "chkOverwrite";
            chkOverwrite.Size = new System.Drawing.Size(110, 25);
            chkOverwrite.TabIndex = 7;
            chkOverwrite.Text = "Overwrite";
            chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // chk2SimplifiedChinese
            // 
            chk2SimplifiedChinese.AutoSize = true;
            chk2SimplifiedChinese.Location = new System.Drawing.Point(10, 53);
            chk2SimplifiedChinese.Name = "chk2SimplifiedChinese";
            chk2SimplifiedChinese.Size = new System.Drawing.Size(84, 25);
            chk2SimplifiedChinese.TabIndex = 6;
            chk2SimplifiedChinese.Text = "转简体";
            chk2SimplifiedChinese.UseVisualStyleBackColor = true;
            // 
            // chkChineseNumber
            // 
            chkChineseNumber.AutoSize = true;
            chkChineseNumber.Location = new System.Drawing.Point(68, 54);
            chkChineseNumber.Name = "chkChineseNumber";
            chkChineseNumber.Size = new System.Drawing.Size(162, 25);
            chkChineseNumber.TabIndex = 5;
            chkChineseNumber.Text = "中文🡆阿拉伯数字";
            chkChineseNumber.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(152, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 21);
            label1.TabIndex = 3;
            label1.Text = "🡆";
            // 
            // btnDoRename
            // 
            btnDoRename.Location = new System.Drawing.Point(350, 22);
            btnDoRename.Name = "btnDoRename";
            btnDoRename.Size = new System.Drawing.Size(103, 50);
            btnDoRename.TabIndex = 2;
            btnDoRename.Text = "Rename GO!";
            btnDoRename.UseVisualStyleBackColor = true;
            btnDoRename.Click += btnDoRename_Click;
            // 
            // txtReplaceNew
            // 
            txtReplaceNew.Location = new System.Drawing.Point(196, 24);
            txtReplaceNew.Name = "txtReplaceNew";
            txtReplaceNew.Size = new System.Drawing.Size(130, 29);
            txtReplaceNew.TabIndex = 1;
            // 
            // txtReplaceOld
            // 
            txtReplaceOld.Location = new System.Drawing.Point(10, 24);
            txtReplaceOld.Name = "txtReplaceOld";
            txtReplaceOld.Size = new System.Drawing.Size(135, 29);
            txtReplaceOld.TabIndex = 0;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(15, 92);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(55, 21);
            lblVersion.TabIndex = 13;
            lblVersion.Text = "label2";
            // 
            // chkDir
            // 
            chkDir.AutoSize = true;
            chkDir.Location = new System.Drawing.Point(386, 50);
            chkDir.Name = "chkDir";
            chkDir.Size = new System.Drawing.Size(117, 25);
            chkDir.TabIndex = 14;
            chkDir.Text = "Directories";
            chkDir.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1135, 541);
            Controls.Add(chkDir);
            Controls.Add(lblVersion);
            Controls.Add(groupBox1);
            Controls.Add(cbSizeOption);
            Controls.Add(chkMedia);
            Controls.Add(btnFormatFN);
            Controls.Add(btnFix);
            Controls.Add(btnTags);
            Controls.Add(btnLookupFolder);
            Controls.Add(comboBox1);
            Controls.Add(lv);
            Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FormMain";
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
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkDir;
    }
}

