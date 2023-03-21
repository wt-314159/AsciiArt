﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    public interface IAsciiGenerator<T>
    {
        string GetAsciiArt(T obj);
        string GetAsciiArt(T obj, int maxWidth, int maxHeight, bool negative);
    }
}
