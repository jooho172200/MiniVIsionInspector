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

        public static Bitmap AdjustBrightnessContrast(Bitmap src, int brightness, int contrast)
        {
            var dst = new Bitmap(src.Width, src.Height);

            double c = (100.0 + contrast) / 100.0;
            c *= c;

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color col = src.GetPixel(x, y);

                    int r = AdjustChannel(col.R, brightness, c);
                    int g = AdjustChannel(col.G, brightness, c);
                    int b = AdjustChannel(col.B, brightness, c);

                    dst.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return dst;
        }

        private static int AdjustChannel(int value, int brightness, double contrastFactor)
        {
            // 0~255 범위에서 중간값(128) 기준으로 contrast 조절
            double v = value / 255.0;
            v -= 0.5;
            v *= contrastFactor;
            v += 0.5;

            v *= 255.0;
            v += brightness; // 밝기 더하기

            if (v < 0) v = 0;
            if (v > 255) v = 255;
            return (int)v;
        }

        public static Bitmap Blur(Bitmap src)
        {
            var dst = new Bitmap(src.Width, src.Height);

            int width = src.Width;
            int height = src.Height;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if(x == 0 || y==0 || x == width-1 || y == height - 1)
                    {
                        dst.SetPixel(x, y, src.GetPixel(x, y));
                        continue;
                    }

                    int sumR = 0, sumG = 0, sumB = 0;

                    for(int j= -1; j <= 1; j++)
                    {
                        for(int i = -1; i <= 1; i++)
                        {
                            Color c = src.GetPixel(x+i, y+j);
                            sumR += c.R;
                            sumG += c.G;
                            sumB += c.B;
                        }
                    }

                    int r = sumR / 9;
                    int g = sumG / 9;
                    int b = sumB / 9;

                    dst.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return dst;
        }

        public static Bitmap Sharpen(Bitmap src)
        {
            var dst = new Bitmap(src.Width, src.Height);

            int width = src.Width;
            int height = src.Height;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if(x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        dst.SetPixel(x, y, src.GetPixel(x, y));
                        continue;
                    }

                    double sumR = 0, sumG = 0, sumB = 0;

                    for(int j = -1; j <= 1; j++)
                    {
                        for(int i=-1 ; i <= 1; i++)
                        {
                            Color c = src.GetPixel(x + i, y + j);
                            int k = 0;

                            if (i == 0 && j == 0) k = 5;
                            else if (i == 0 || j == 0) k = -1;
                            else k = 0;

                            sumR += c.R * k;
                            sumG += c.G * k;
                            sumB += c.B * k;
                        }

                    }

                    int r = (int)Math.Round(sumR);
                    int g = (int)Math.Round(sumG);
                    int b = (int)Math.Round(sumB);

                    if (r < 0) r = 0; if (r > 255) r = 255;
                    if (g < 0) g = 0; if (g > 255) g = 255;
                    if (b < 0) b = 0; if (b > 255) b = 255;

                    dst.SetPixel(x, y, Color.FromArgb(r, g, b));

                }
            }

            return dst;
        }


    }

}
