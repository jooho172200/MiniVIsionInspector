using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVisionInspector.Services
{
    internal class ImageProcessor
    {
        public static Bitmap ToGrayScale(Bitmap src)
        {
            var dst = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < dst.Height; y++)
            {
                for (int x = 0; x < dst.Width; x++)
                {
                    Color c = src.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    dst.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return dst;
        }

        public static Bitmap Threshold(Bitmap src, int th)
        {
            var dst = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < dst.Height; y++)
            {
                for (int x = 0; x < dst.Width; x++)
                {
                    Color c = src.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    Color outColor = gray >= th ? Color.White : Color.Black;
                    dst.SetPixel(x, y, outColor);
                }
            }

            return dst;
        }

        public static Bitmap Threshold(Bitmap src, int th, bool invert)
        {
            var dst = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < dst.Height; y++)
            {
                for (int x = 0; x < dst.Width; x++)
                {
                    Color c = src.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;

                    bool isWhite = gray >= th;
                    if (invert) isWhite = !isWhite;

                    dst.SetPixel(x, y, isWhite ? Color.White : Color.Black); 
                }
            }

            return dst;
        }
    }

}
