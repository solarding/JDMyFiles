
namespace JD.PhotoDuplicates
{
    partial class FormMainDuplicate
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
            components = new System.ComponentModel.Container();
            ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            ListViewItem listViewItem3 = new ListViewItem("");
            ListViewItem listViewItem4 = new ListViewItem("");
            ListViewItem listViewItem5 = new ListViewItem("");
            folderBrowserDialog1 = new FolderBrowserDialog();
            lv = new ListView();
            ColumnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Keep = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            panel1 = new Panel();
            btnSave = new Button();
            btnLoad = new Button();
            btnDelDuplicate = new Button();
            btnRefreshList = new Button();
            progressBar1 = new ProgressBar();
            btnStop = new Button();
            lblInfo = new Label();
            btnLookUpFolder = new Button();
            lblVersion = new Label();
            btnScan = new Button();
            comboBox1 = new ComboBox();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lv
            // 
            lv.Activation = ItemActivation.TwoClick;
            lv.AllowColumnReorder = true;
            lv.Columns.AddRange(new ColumnHeader[] { ColumnHeader1, columnHeader2, Keep, columnHeader4, columnHeader5, columnHeader6 });
            lv.Dock = DockStyle.Bottom;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup2";
            lv.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
            lv.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5 });
            lv.LabelEdit = true;
            lv.Location = new Point(0, 75);
            lv.Margin = new Padding(3, 4, 3, 4);
            lv.MultiSelect = false;
            lv.Name = "lv";
            lv.ShowGroups = false;
            lv.Size = new Size(1157, 464);
            lv.TabIndex = 1;
            lv.UseCompatibleStateImageBehavior = false;
            lv.View = View.Details;
            lv.ColumnClick += lv_ColumnClick;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            // 
            // ColumnHeader1
            // 
            ColumnHeader1.Name = "ColumnHeader1";
            ColumnHeader1.Text = "HashName";
            ColumnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Name = "columnHeader2";
            columnHeader2.Text = "Duplicates";
            columnHeader2.Width = 100;
            // 
            // Keep
            // 
            Keep.Text = "Keep";
            Keep.Width = 300;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Kill1";
            columnHeader4.Width = 300;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Kill2";
            columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Rest of Kills";
            columnHeader6.Width = 150;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(btnDelDuplicate);
            panel1.Controls.Add(btnRefreshList);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(btnStop);
            panel1.Controls.Add(lblInfo);
            panel1.Controls.Add(btnLookUpFolder);
            panel1.Controls.Add(lblVersion);
            panel1.Controls.Add(btnScan);
            panel1.Controls.Add(comboBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1157, 72);
            panel1.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ButtonHighlight;
            btnSave.Image = Properties.Resources.SaveStatusBar2_16x;
            btnSave.Location = new Point(542, 13);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(26, 26);
            btnSave.TabIndex = 27;
            toolTip1.SetToolTip(btnSave, "Save the results as Json");
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.ButtonHighlight;
            btnLoad.Image = Properties.Resources.Open_16x;
            btnLoad.Location = new Point(574, 13);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(26, 26);
            btnLoad.TabIndex = 26;
            toolTip1.SetToolTip(btnLoad, "Load saved Json and continue");
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDelDuplicate
            // 
            btnDelDuplicate.Image = Properties.Resources.CleanData_16x;
            btnDelDuplicate.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelDuplicate.Location = new Point(709, 13);
            btnDelDuplicate.Name = "btnDelDuplicate";
            btnDelDuplicate.Size = new Size(161, 26);
            btnDelDuplicate.TabIndex = 25;
            btnDelDuplicate.Text = "Delete Non-Kept";
            btnDelDuplicate.UseVisualStyleBackColor = true;
            btnDelDuplicate.Click += btnDelDuplicate_Click;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Location = new Point(606, 13);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(97, 26);
            btnRefreshList.TabIndex = 24;
            btnRefreshList.Text = "Rebuild List";
            btnRefreshList.UseVisualStyleBackColor = true;
            btnRefreshList.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            progressBar1.Location = new Point(1002, 45);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(152, 15);
            progressBar1.TabIndex = 23;
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.Stop_16x;
            btnStop.Location = new Point(501, 13);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(26, 26);
            btnStop.TabIndex = 22;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Visible = false;
            btnStop.Click += btnStop_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.Location = new Point(17, 44);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(16, 16);
            lblInfo.TabIndex = 21;
            lblInfo.Text = "...";
            // 
            // btnLookUpFolder
            // 
            btnLookUpFolder.BackColor = SystemColors.ButtonHighlight;
            btnLookUpFolder.Image = Properties.Resources.OpenFolder_16x;
            btnLookUpFolder.Location = new Point(372, 13);
            btnLookUpFolder.Margin = new Padding(3, 4, 3, 4);
            btnLookUpFolder.Name = "btnLookUpFolder";
            btnLookUpFolder.Size = new Size(26, 26);
            btnLookUpFolder.TabIndex = 20;
            btnLookUpFolder.UseVisualStyleBackColor = false;
            btnLookUpFolder.Click += btnLookupFolder_Click;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(1053, 13);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(42, 17);
            lblVersion.TabIndex = 19;
            lblVersion.Text = "lblVer";
            // 
            // btnScan
            // 
            btnScan.Image = Properties.Resources.LookupGroup_16x;
            btnScan.ImageAlign = ContentAlignment.MiddleLeft;
            btnScan.Location = new Point(404, 13);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(91, 27);
            btnScan.TabIndex = 18;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "D:\\Photos" });
            comboBox1.Location = new Point(17, 15);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(349, 25);
            comboBox1.TabIndex = 17;
            comboBox1.Text = "D:\\Photos";
            // 
            // FormMainDuplicate
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 539);
            Controls.Add(panel1);
            Controls.Add(lv);
            Font = new Font("Microsoft YaHei", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMainDuplicate";
            Text = "Hunting Duplicate Photos";
            Load += OnFormLoad;
            Resize += FormMainDuplicate_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListView lv;        
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        
        private ColumnHeader Keep;
        private ColumnHeader columnHeader4;
        private Panel panel1;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button btnStop;
        private Label lblInfo;
        private Button btnLookUpFolder;
        private Label lblVersion;
        private Button btnScan;
        private ComboBox comboBox1;
        private ProgressBar progressBar1;
        private ColumnHeader columnHeader2;
        private Button btnRefreshList;
        private Button btnDelDuplicate;
        private Button btnSave;
        private Button btnLoad;
        private ToolTip toolTip1;
    }
}

