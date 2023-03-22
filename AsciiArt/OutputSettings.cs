using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    public class OutputSettings
    {
        public bool Negative { get; set; }
        public bool DoubleWidth { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public static OutputSettings Default = new OutputSettings(false, 0, 0);


        public OutputSettings(bool negative, int maxWidth, int maxHeight, bool doubleWidth = true)
        {
            Negative = negative;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            DoubleWidth = doubleWidth;
        }


        public static OutputSettings FromConsoleSize(bool negative, bool doubleWidth = true)
            => new OutputSettings(negative, Console.WindowWidth, Console.WindowHeight, doubleWidth);
    }
}
