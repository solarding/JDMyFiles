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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lv = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnLookupFolder = new System.Windows.Forms.Button();
            this.btnTags = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnFormatFN = new System.Windows.Forms.Button();
            this.chkMedia = new System.Windows.Forms.CheckBox();
            this.cbSizeOption = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk2SimplifiedChinese = new System.Windows.Forms.CheckBox();
            this.chkChineseNumber = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoRename = new System.Windows.Forms.Button();
            this.txtReplaceNew = new System.Windows.Forms.TextBox();
            this.txtReplaceOld = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lv.AllowColumnReorder = true;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.columnHeader2});
            this.lv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv.HideSelection = false;
            this.lv.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lv.LabelEdit = true;
            this.lv.Location = new System.Drawing.Point(0, 105);
            this.lv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv.MultiSelect = false;
            this.lv.Name = "lv";
            this.lv.ShowGroups = false;
            this.lv.Size = new System.Drawing.Size(959, 438);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Name = "ColumnHeader1";
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 265;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Size";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 13);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 25);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "C:\\";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // btnLookupFolder
            // 
            this.btnLookupFolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLookupFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupFolder.Image")));
            this.btnLookupFolder.Location = new System.Drawing.Point(369, 11);
            this.btnLookupFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLookupFolder.Name = "btnLookupFolder";
            this.btnLookupFolder.Size = new System.Drawing.Size(26, 27);
            this.btnLookupFolder.TabIndex = 3;
            this.btnLookupFolder.UseVisualStyleBackColor = false;
            this.btnLookupFolder.Click += new System.EventHandler(this.btnLookupFolder_Click);
            // 
            // btnTags
            // 
            this.btnTags.Location = new System.Drawing.Point(401, 11);
            this.btnTags.Name = "btnTags";
            this.btnTags.Size = new System.Drawing.Size(72, 27);
            this.btnTags.TabIndex = 4;
            this.btnTags.Text = "Scan";
            this.btnTags.UseVisualStyleBackColor = true;
            this.btnTags.Click += new System.EventHandler(this.btnTags_Click);
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(144, 45);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(108, 26);
            this.btnFix.TabIndex = 8;
            this.btnFix.Text = "Guess Tag";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnFormatFN
            // 
            this.btnFormatFN.Location = new System.Drawing.Point(14, 45);
            this.btnFormatFN.Name = "btnFormatFN";
            this.btnFormatFN.Size = new System.Drawing.Size(124, 27);
            this.btnFormatFN.TabIndex = 9;
            this.btnFormatFN.Text = "Format file name";
            this.btnFormatFN.UseVisualStyleBackColor = true;
            this.btnFormatFN.Click += new System.EventHandler(this.bntFormatFN_Click);
            // 
            // chkMedia
            // 
            this.chkMedia.AutoSize = true;
            this.chkMedia.Location = new System.Drawing.Point(274, 49);
            this.chkMedia.Name = "chkMedia";
            this.chkMedia.Size = new System.Drawing.Size(93, 21);
            this.chkMedia.TabIndex = 10;
            this.chkMedia.Text = "Media Files";
            this.chkMedia.UseVisualStyleBackColor = true;
            // 
            // cbSizeOption
            // 
            this.cbSizeOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbSizeOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSizeOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSizeOption.FormattingEnabled = true;
            this.cbSizeOption.Items.AddRange(new object[] {
            " B",
            "in KB",
            "in MB",
            "in GB"});
            this.cbSizeOption.Location = new System.Drawing.Point(401, 49);
            this.cbSizeOption.Name = "cbSizeOption";
            this.cbSizeOption.Size = new System.Drawing.Size(72, 25);
            this.cbSizeOption.TabIndex = 11;
            this.cbSizeOption.SelectedIndexChanged += new System.EventHandler(this.cbSizeOption_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk2SimplifiedChinese);
            this.groupBox1.Controls.Add(this.chkChineseNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDoRename);
            this.groupBox1.Controls.Add(this.txtReplaceNew);
            this.groupBox1.Controls.Add(this.txtReplaceOld);
            this.groupBox1.Location = new System.Drawing.Point(512, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 94);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "manipulate name";
            // 
            // chk2SimplifiedChinese
            // 
            this.chk2SimplifiedChinese.AutoSize = true;
            this.chk2SimplifiedChinese.Location = new System.Drawing.Point(6, 56);
            this.chk2SimplifiedChinese.Name = "chk2SimplifiedChinese";
            this.chk2SimplifiedChinese.Size = new System.Drawing.Size(63, 21);
            this.chk2SimplifiedChinese.TabIndex = 6;
            this.chk2SimplifiedChinese.Text = "转简体";
            this.chk2SimplifiedChinese.UseVisualStyleBackColor = true;
            // 
            // chkChineseNumber
            // 
            this.chkChineseNumber.AutoSize = true;
            this.chkChineseNumber.Location = new System.Drawing.Point(163, 56);
            this.chkChineseNumber.Name = "chkChineseNumber";
            this.chkChineseNumber.Size = new System.Drawing.Size(122, 21);
            this.chkChineseNumber.TabIndex = 5;
            this.chkChineseNumber.Text = "中文🡆阿拉伯数字";
            this.chkChineseNumber.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "🡆";
            // 
            // btnDoRename
            // 
            this.btnDoRename.Location = new System.Drawing.Point(336, 22);
            this.btnDoRename.Name = "btnDoRename";
            this.btnDoRename.Size = new System.Drawing.Size(77, 55);
            this.btnDoRename.TabIndex = 2;
            this.btnDoRename.Text = "Rename GO!";
            this.btnDoRename.UseVisualStyleBackColor = true;
            this.btnDoRename.Click += new System.EventHandler(this.btnDoRename_Click);
            // 
            // txtReplaceNew
            // 
            this.txtReplaceNew.Location = new System.Drawing.Point(163, 25);
            this.txtReplaceNew.Name = "txtReplaceNew";
            this.txtReplaceNew.Size = new System.Drawing.Size(120, 23);
            this.txtReplaceNew.TabIndex = 1;
            // 
            // txtReplaceOld
            // 
            this.txtReplaceOld.Location = new System.Drawing.Point(6, 25);
            this.txtReplaceOld.Name = "txtReplaceOld";
            this.txtReplaceOld.Size = new System.Drawing.Size(128, 23);
            this.txtReplaceOld.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(16, 82);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(43, 17);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "label2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 543);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbSizeOption);
            this.Controls.Add(this.chkMedia);
            this.Controls.Add(this.btnFormatFN);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnLookupFolder);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lv);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Audio Tag";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

