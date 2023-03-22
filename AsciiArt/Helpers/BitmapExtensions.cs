using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Helpers
{
    public static class BitmapExtensions
    {
        public static Bitmap ScaleToFit(this Bitmap bmp, OutputSettings settings)
            => ScaleToFit(
                bmp,
                settings.DoubleWidth ? settings.MaxWidth / 2 : settings.MaxWidth,
                settings.MaxHeight);

        public static Bitmap ScaleToFit(this Bitmap bmp, double maxWidth, double maxHeight)
        {
            maxWidth = maxWidth == 0 ? bmp.Width : maxWidth;
            maxHeight = maxHeight == 0 ? bmp.Height : maxHeight;
            if (bmp.Width <= maxWidth && bmp.Height <= maxHeight) { return bmp; }


            var widthScalingFactor = maxWidth / bmp.Width;
            var heightScalingFactor = maxHeight / bmp.Height;
            var scalingFactor = widthScalingFactor < heightScalingFactor ? widthScalingFactor : heightScalingFactor;
            return new Bitmap(bmp, new Size((int)(bmp.Width * scalingFactor), (int)(bmp.Height * scalingFactor)));
        }

        public static Bitmap Crop(this Bitmap bmp, int width, int height)
        {
            width = bmp.Width < width ? bmp.Width : width;
            height = bmp.Height < height ? bmp.Height : height;
            int widthDiff = (bmp.Width - width) / 2;
            int heightDiff = (bmp.Height - height) / 2;

            var cropped = new Bitmap(width, height);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    cropped.SetPixel(i, j, bmp.GetPixel(i + widthDiff, j + heightDiff));
                }
            }
            return cropped;
        }
    }
}
