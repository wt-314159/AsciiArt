using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.Helpers
{
    public static class Extensions
    {
        public static int Grayscale(this Color pixel)
        {
            return (pixel.R + pixel.G + pixel.B) / 3;
        }

        public static bool SetZoom(ref int zoom, char key)
        {
            if (key == '+')
            {
                if (zoom == 1)
                {
                    Console.WriteLine("Can't zoom in any further.");
                    return false;
                }
                zoom--;
            }
            else if (key == '-')
            {
                if (zoom == 10)
                {
                    Console.WriteLine("Can't zoom out any further.");
                    return false;
                }
                zoom++;
            }
            return true;
        }
    }
}
