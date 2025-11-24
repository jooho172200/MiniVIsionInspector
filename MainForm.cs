namespace MiniVIsionInspector
{
    public partial class MainForm : Form
    {
        private Bitmap _originalImage;
        private Bitmap _currentImage;

        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabelInfo.Text = "이미지를 Open 버튼으로 불러오세요.";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnGray_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {

        }

        private void btnThresh_Click(object sender, EventArgs e)
        {

        }
    }
}
