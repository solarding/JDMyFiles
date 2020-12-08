namespace JD
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lv = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnLookupFolder = new System.Windows.Forms.Button();
            this.btnTags = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnFormatFN = new System.Windows.Forms.Button();
            this.chkMedia = new System.Windows.Forms.CheckBox();
            this.cbSizeOption = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1});
            this.lv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lv.GridLines = true;
            this.lv.HideSelection = false;
            this.lv.Location = new System.Drawing.Point(0, 105);
            this.lv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(959, 438);
            this.lv.TabIndex = 1;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Name = "ColumnHeader1";
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 265;
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
            "in Byte",
            "in KB",
            "in MB",
            "in GB"});
            this.cbSizeOption.Location = new System.Drawing.Point(401, 49);
            this.cbSizeOption.Name = "cbSizeOption";
            this.cbSizeOption.Size = new System.Drawing.Size(72, 25);
            this.cbSizeOption.TabIndex = 11;
            this.cbSizeOption.SelectedIndexChanged += new System.EventHandler(this.cbSizeOption_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 543);
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
    }
}

