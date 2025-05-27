
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
            ListViewGroup listViewGroup3 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewGroup listViewGroup4 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            ListViewItem listViewItem6 = new ListViewItem("");
            ListViewItem listViewItem7 = new ListViewItem("");
            ListViewItem listViewItem8 = new ListViewItem("");
            ListViewItem listViewItem9 = new ListViewItem("");
            ListViewItem listViewItem10 = new ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainDuplicate));
            folderBrowserDialog1 = new FolderBrowserDialog();
            lv = new ListView();
            ColumnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Keep = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            panel1 = new Panel();
            btnRefreshList = new Button();
            progressBar1 = new ProgressBar();
            btnStop = new Button();
            lblInfo = new Label();
            btnLookUpFolder = new Button();
            lblVersion = new Label();
            btnScan = new Button();
            comboBox1 = new ComboBox();
            btnDelDuplicate = new Button();
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
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup2";
            lv.Groups.AddRange(new ListViewGroup[] { listViewGroup3, listViewGroup4 });
            lv.Items.AddRange(new ListViewItem[] { listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10 });
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
            // btnRefreshList
            // 
            btnRefreshList.Location = new Point(541, 14);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(97, 25);
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
            btnStop.Location = new Point(482, 14);
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
            btnLookUpFolder.Image = (Image)resources.GetObject("btnLookUpFolder.Image");
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
            btnScan.Location = new Point(404, 13);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(72, 27);
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
            // btnDelDuplicate
            // 
            btnDelDuplicate.Location = new Point(644, 15);
            btnDelDuplicate.Name = "btnDelDuplicate";
            btnDelDuplicate.Size = new Size(161, 25);
            btnDelDuplicate.TabIndex = 25;
            btnDelDuplicate.Text = "Delete Non-Kept";
            btnDelDuplicate.UseVisualStyleBackColor = true;
            btnDelDuplicate.Click += btnDelDuplicate_Click;
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
        private System.Windows.Forms.Button btnLookupFolder;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader colDupCount;
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
    }
}

