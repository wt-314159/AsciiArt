using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    public static class Extensions
    {
        public static int Grayscale(this Color pixel)
        {
            return (pixel.R + pixel.G + pixel.B) / 3;
        }

        public static Bitmap ScaleToFit(this Bitmap bmp, double maxWidth)
        {
            if (bmp.Width < maxWidth) { return bmp; }

            var scalingFactor = maxWidth / bmp.Width;
            return new Bitmap(bmp, new Size((int)(bmp.Width * scalingFactor), (int)(bmp.Height * scalingFactor)));
        }
    }
}
