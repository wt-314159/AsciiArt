using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using AsciiArt.AsciiCharacterProviders;
using AsciiArt.Helpers;

namespace AsciiArt.AsciiGenerators
{
    public class BitmapAsciiGenerator : AsciiGeneratorBase<Bitmap>
    {
        public Func<Color, int> GetPixelValue { get; set; }

        public BitmapAsciiGenerator() : this(x => x.Grayscale())
        { }

        public BitmapAsciiGenerator(Func<Color, int> getPixelValue)
        {
            GetPixelValue = getPixelValue;
        }

        public override string GetAsciiArt(
            Bitmap bmp, 
            IAsciiCharacterProvider provider, 
            OutputSettings settings)
        {
            bmp = bmp.ScaleToFit(settings);
            var builder = EmptyStringBuilder(bmp.Width, bmp.Height);
            var repeatCount = settings.DoubleWidth ? 2 : 1;

            LoopRowsThenColumns(bmp.Width, bmp.Height, (i, j) =>
            {
                var pixel = bmp.GetPixel(i, j);
                var pixelValue = GetPixelValue(pixel);
                var ascii = provider.GetAsciiChar(pixelValue, settings.Negative);
                builder.Append(ascii, repeatCount);
            },
            j => builder.AppendLine());

            return builder.ToString();
        }
    }
}
