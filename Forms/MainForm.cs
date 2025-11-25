using MiniVisionInspector.Services;
using MiniVisionInspector.Forms;

namespace MiniVisionInspector
{
    public partial class MainForm : Form
    {
        private Bitmap _originalImage;
        private Bitmap _currentImage;

        private int _lastThreshold = 127;
        private bool _lastInvert = false;

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
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _originalImage?.Dispose();
                    _currentImage?.Dispose();

                    _originalImage = new Bitmap(ofd.FileName);
                    _currentImage = (Bitmap)_originalImage.Clone();

                    pictureBoxOriginal.Image = _originalImage;
                    pictureBoxProcessed.Image = _currentImage;

                    toolStripStatusLabelInfo.Text = $"이미지 로드: {ofd.FileName}";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            _currentImage?.Dispose();
            _currentImage = (Bitmap)_originalImage.Clone();
            pictureBoxProcessed.Image= _currentImage;

            toolStripStatusLabelInfo.Text = "변경 사항 폐기 완료";
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            var src = _currentImage;
            _currentImage = ImageProcessor.ToGrayScale(src);
            src.Dispose();

            pictureBoxProcessed.Image=_currentImage;
            toolStripStatusLabelInfo.Text = "그레이스케일 변환 완료";
        }

        private void btnThresh_Click(object sender, EventArgs e)
        {
            if (_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            using(var dlg = new Threshold(_lastThreshold))
            {
                var result = dlg.ShowDialog(this);

                if(result != DialogResult.OK)
                {
                    toolStripStatusLabelInfo.Text = "이진화 취소";
                    return;
                }

                int th = dlg.SelectedThreshold;
                bool invert = dlg.BitInvert;

                _lastThreshold = th;
                _lastInvert = invert;

                var src = _currentImage;
                _currentImage = ImageProcessor.Threshold(src, th, invert);
                src.Dispose();

                pictureBoxProcessed.Image = _currentImage;
                toolStripStatusLabelInfo.Text = $"이진화(threshold = {th}) 완료";
            }                       
        }

        private void pictureBoxOriginal_Click(object sender, EventArgs e)
        {

        }

    }
}
