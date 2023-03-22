using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.AsciiCharacterProviders
{
    public interface IAsciiCharacterProvider
    {
        char GetAsciiChar(int value, bool negative);
    }
}
