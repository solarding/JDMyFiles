namespace JD.PhotoDuplicates
{
    public partial class ImageView : Form
    {
        public ImageView(List<FileInfo> filePaths)
        {
            InitializeComponent();
            InitializeImages(filePaths);
        }

        private void InitializeImages(List<FileInfo> files)
        {
            this.Text = "Duplicate Images";
            this.AutoScroll = true;
            this.Width = 1000;
            this.Height = 600;

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight
            };
            this.Controls.Add(panel);

            foreach (var f in files)
            {               
                try
                {
                    var picBox = new PictureBox
                    {
                        Image = Image.FromFile(f.FullName),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 350,
                        Height = 350,
                        Margin = new Padding(10)
                    };

                    var label1 = new Label
                    {
                        Text = $"Path: {Path.GetDirectoryName(f.FullName)}",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,                        
                    };
                    var label2 = new Label
                    {
                        Text = $"Name: {f.Name} ({f.Length / 1024} KB)",
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };

                    var container = new Panel
                    {
                        Width = 350,
                        Height = 400
                    };
                    container.Controls.Add(picBox);
                    container.Controls.Add(label1);
                    container.Controls.Add(label2);

                    label1.Dock = DockStyle.Bottom;
                    label2.Dock = DockStyle.Bottom;
                    picBox.Dock = DockStyle.Top;

                    panel.Controls.Add(container);
                }
                catch (Exception ex)
                {
                    // You can optionally log this
                    Console.WriteLine($"Failed to load image {f.FullName}: {ex.Message}");
                }
            }
        }
    }
}
