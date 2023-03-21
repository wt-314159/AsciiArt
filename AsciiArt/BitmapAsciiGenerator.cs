using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    public class BitmapAsciiGenerator : IAsciiGenerator<Bitmap>
    {
        public Func<Color, int> GetPixelValue { get; set; }
        public string OrderedAsciiSet { get; private set; }

        public BitmapAsciiGenerator() : this(" .,:ilwW@@", x => x.Grayscale())
        { }

        public BitmapAsciiGenerator(string orderedAsciiSet, Func<Color, int> getPixelValue)
        {
            OrderedAsciiSet = orderedAsciiSet;
            GetPixelValue = getPixelValue;
        }
        
        public string GetAsciiArt(Bitmap bmp)
            => GetAsciiArt(bmp, bmp.Width);

        public string GetAsciiArt(Bitmap bmp, int maxWidth)
        {
            bmp = bmp.ScaleToFit(maxWidth / 2);

            var length = OrderedAsciiSet.Length - 1;
            var builder = new StringBuilder(bmp.Width * bmp.Height + bmp.Height * "\r\n".Length);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    var pixel = bmp.GetPixel(j, i);
                    var pixelValue = GetPixelValue(pixel);
                    var index = pixelValue * length / 255;
                    builder.Append(OrderedAsciiSet[index]);
                    builder.Append(OrderedAsciiSet[index]);
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
