namespace JD.PhotoDuplicates
{
    public partial class ImageView : Form
    {
        public ImageView(List<string> filePaths)
        {
            InitializeComponent();
            InitializeImages(filePaths);
        }

        private void InitializeImages(List<string> filePaths)
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

            foreach (var path in filePaths)
            {
                try
                {
                    var picBox = new PictureBox
                    {
                        Image = Image.FromFile(path),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 300,
                        Height = 300,
                        Margin = new Padding(10)
                    };

                    var label = new Label
                    {
                        Text = Path.GetFileName(path),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    var container = new Panel
                    {
                        Width = 300,
                        Height = 340
                    };
                    container.Controls.Add(picBox);
                    container.Controls.Add(label);

                    label.Dock = DockStyle.Bottom;
                    picBox.Dock = DockStyle.Top;

                    panel.Controls.Add(container);
                }
                catch (Exception ex)
                {
                    // You can optionally log this
                    Console.WriteLine($"Failed to load image {path}: {ex.Message}");
                }
            }
        }
    }
}
