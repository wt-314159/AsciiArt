using AsciiArt.AsciiCharacterProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.AsciiGenerators
{
    public interface IAsciiGenerator<T>
    {
        string GetAsciiArt(T obj, IAsciiCharacterProvider charProvider);
        string GetAsciiArt(T obj, IAsciiCharacterProvider charProvider, OutputSettings settings);
    }
}
