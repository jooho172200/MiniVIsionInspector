using MiniVisionInspector.Services;
using MiniVisionInspector.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace MiniVisionInspector
{
    public partial class MainForm : Form
    {
        private Bitmap _originalImage;
        private Bitmap _currentImage;

        private int _lastThreshold = 127;
        private bool _lastInvert = false;

        private int _lastBrightness = 0;
        private int _lastContrast = 0;

        private readonly Stack<Bitmap> _history = new Stack<Bitmap>();

        // true  : 원본 이미지 표시
        // false : 현재(_currentImage) 이미지 표시
        private bool _showOriginal = false;

        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabelInfo.Text = "이미지를 Open 버튼으로 불러오세요.";
        }

        /// <summary>
        /// 현재 상태(_showOriginal)에 맞게 pictureBoxMain에 이미지 표시
        /// </summary>
        private void RefreshImage()
        {
            if (_originalImage is null)
            {
                pictureBoxMain.Image = null;
                return;
            }

            if (_showOriginal)
            {
                pictureBoxMain.Image = _originalImage;
            }
            else
            {
                // 아직 가공된 이미지가 없다면 원본을 대신 보여줌
                pictureBoxMain.Image = _currentImage ?? _originalImage;
            }
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

                    ClearHistory();
                    _showOriginal = false;   // 기본은 가공 이미지 모드

                    RefreshImage();

                    toolStripStatusLabelInfo.Text = $"이미지 로드: {ofd.FileName}";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            _currentImage?.Dispose();
            _currentImage = (Bitmap)_originalImage.Clone();
            _showOriginal = false;

            RefreshImage();

            toolStripStatusLabelInfo.Text = "변경 사항 폐기 완료";
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            if (_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            PushHistory();

            var src = _currentImage;
            _currentImage = ImageProcessor.ToGrayScale(src);
            src.Dispose();

            _showOriginal = false;
            RefreshImage();

            toolStripStatusLabelInfo.Text = "그레이스케일 변환 완료";
        }

        private void btnThresh_Click(object sender, EventArgs e)
        {
            if (_originalImage is null)
            {
                toolStripStatusLabelInfo.Text = "원본 이미지가 없습니다";
                return;
            }

            using (var dlg = new Threshold(_lastThreshold))
            {
                var result = dlg.ShowDialog(this);

                if (result != DialogResult.OK)
                {
                    toolStripStatusLabelInfo.Text = "이진화 취소";
                    return;
                }

                int th = dlg.SelectedThreshold;
                bool invert = dlg.BitInvert;

                _lastThreshold = th;
                _lastInvert = invert;

                PushHistory();

                var src = _currentImage;
                _currentImage = ImageProcessor.Threshold(src, th, invert);
                src.Dispose();

                _showOriginal = false;
                RefreshImage();

                toolStripStatusLabelInfo.Text = $"이진화(threshold = {th}) 완료";
            }
        }

        // 사진창 위에서 마우스 움직일 때 좌표와 RGB 값 표시용
        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            // 현재 보여주고 있는 이미지 선택
            var img = _showOriginal ? _originalImage : _currentImage;

            if (img == null || pictureBoxMain.Image == null)
            {
                toolStripStatusLabelInfo.Text = "이미지를 먼저 열어주세요.";
                return;
            }

            // 사진창과 이미지의 비율 계산
            float imgAspect = (float)img.Width / img.Height;
            float boxAspect = (float)pictureBoxMain.Width / pictureBoxMain.Height;

            int drawWidth, drawHeight;
            int offsetX, offsetY;

            if (imgAspect > boxAspect)  // 가로가 더 긴 경우
            {
                drawWidth = pictureBoxMain.Width;
                drawHeight = (int)(pictureBoxMain.Width / imgAspect);
                offsetX = 0;
                offsetY = (pictureBoxMain.Height - drawHeight) / 2;
            }
            else
            {
                drawHeight = pictureBoxMain.Height;
                drawWidth = (int)(pictureBoxMain.Height * imgAspect);
                offsetY = 0;
                offsetX = (pictureBoxMain.Width - drawWidth) / 2;
            }

            // 마우스 좌표 -> 이미지 좌표 변환
            int x = (int)((e.X - offsetX) * (float)img.Width / drawWidth);
            int y = (int)((e.Y - offsetY) * (float)img.Height / drawHeight);

            // 이미지 영역 밖인 경우
            if (x < 0 || y < 0 || x >= img.Width || y >= img.Height)
            {
                return;
            }

            Color c = img.GetPixel(x, y);
            toolStripStatusLabelInfo.Text = $"X={x}, Y={y}       R={c.R}, G={c.G}, B={c.B}";
        }

        // 결과 이미지 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                toolStripStatusLabelInfo.Text = "저장할 이미지 없음";
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "이미지 저장";
                sfd.Filter = "PNG 이미지|*.png|JPEG 이미지|*.jpg;*.jpeg|BMP 이미지|*.bmp|모든 파일|*.*";
                sfd.FileName = "result.png";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(sfd.FileName).ToLowerInvariant();
                        ImageFormat format;

                        switch (ext)
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            case ".png":
                            default:
                                format = ImageFormat.Png;
                                break;
                        }

                        _currentImage.Save(sfd.FileName, format);
                        toolStripStatusLabelInfo.Text = $"이미지 저장 완료: {sfd.FileName}";
                    }
                    catch (Exception)
                    {
                        toolStripStatusLabelInfo.Text = "이미지 저장 중 오류 발생";
                    }
                }
                else
                {
                    toolStripStatusLabelInfo.Text = "이미지 저장 취소";
                }
            }
        }

        private void btnBrightnessContrast_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                toolStripStatusLabelInfo.Text = "이미지를 먼저 열어주세요.";
                return;
            }

            using (var dlg = new BrightnessContrast(_lastBrightness, _lastContrast))
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    toolStripStatusLabelInfo.Text = "밝기/대비 조정 취소";
                    return;
                }

                int b = dlg.Brightness;
                int c = dlg.Contrast;

                _lastBrightness = b;
                _lastContrast = c;

                PushHistory();

                var src = _currentImage;
                _currentImage = ImageProcessor.AdjustBrightnessContrast(src, b, c);
                src.Dispose();

                _showOriginal = false;
                RefreshImage();

                toolStripStatusLabelInfo.Text = $"밝기={b}, 대비={c} 적용완료";
            }
        }

        // 현재 이미지를 히스토리에 저장
        private void PushHistory()
        {
            if (_currentImage is not null)
            {
                _history.Push((Bitmap)_currentImage.Clone());
            }
        }

        // 새 이미지 열 때, 히스토리 초기화
        private void ClearHistory()
        {
            while (_history.Count > 0)
            {
                var bmp = _history.Pop();
                bmp.Dispose();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_history.Count == 0)
            {
                toolStripStatusLabelInfo.Text = "되돌릴 작업이 없습니다";
                return;
            }

            _currentImage?.Dispose();
            _currentImage = _history.Pop();

            _showOriginal = false;
            RefreshImage();

            toolStripStatusLabelInfo.Text = "Undo 완료";
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                toolStripStatusLabelInfo.Text = "이미지를 먼저 열어주세요.";
                return;
            }

            PushHistory();

            var src = _currentImage;
            _currentImage = ImageProcessor.Blur(src);
            src.Dispose();

            _showOriginal = false;
            RefreshImage();

            toolStripStatusLabelInfo.Text = "3x3  평균 블러 적용 완료";
        }

        private void btnSharpen_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                toolStripStatusLabelInfo.Text = "이미지를 먼저 열어주세요";
                return;
            }

            PushHistory();

            var src = _currentImage;
            _currentImage = ImageProcessor.Sharpen(src);
            src.Dispose();

            _showOriginal = false;
            RefreshImage();

            toolStripStatusLabelInfo.Text = "샤프닝 필터 적용 완료";
        }

        // OpenCV
        private void btnCanny_Click(object sender, EventArgs e)
        {
            if (_currentImage is null)
            {
                toolStripStatusLabelInfo.Text = "이미지를 먼저 열어주세요";
                return;
            }

            PushHistory();

            var src = _currentImage;
            _currentImage = ImageProcessor.Canny(src, 100, 200);
            src.Dispose();

            _showOriginal = false;
            RefreshImage();

            toolStripStatusLabelInfo.Text = "Canny 엣지 검출 완료";
        }
    }
}
