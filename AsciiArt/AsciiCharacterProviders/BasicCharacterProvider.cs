using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.AsciiCharacterProviders
{
    public class BasicCharacterProvider : IAsciiCharacterProvider
    {
        public static BasicCharacterProvider HighContrast = new BasicCharacterProvider(" .,:ilwW@@");

        public int SetLength => AsciiSet.Length;
        public int MaxIndex => AsciiSet.Length - 1;
        public string AsciiSet { get; }


        public BasicCharacterProvider(string asciiSet)
        {
            AsciiSet = asciiSet;
        }


        public char GetAsciiChar(int value, bool negative)
        {
            var index = value * MaxIndex / 255;
            index = negative ? MaxIndex - index : index;
            return AsciiSet[index];
        }
    }
}
