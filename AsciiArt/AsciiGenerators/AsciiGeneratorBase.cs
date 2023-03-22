using AsciiArt.AsciiCharacterProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt.AsciiGenerators
{
    public abstract class AsciiGeneratorBase<T> : IAsciiGenerator<T>
    {
        public virtual string GetAsciiArt(T obj, IAsciiCharacterProvider provider)
            => GetAsciiArt(obj, provider, OutputSettings.Default);

        public abstract string GetAsciiArt(T obj, IAsciiCharacterProvider provider, OutputSettings settings);

        public virtual void LoopRowsThenColumns(
            int width, 
            int height, 
            Action<int, int> columnAction, 
            Action<int> rowEndAction)
        {
            // Iterate over rows
            for (int j = 0; j < height; j++)
            {
                // In each row, iterate through columns
                for (int i = 0; i < width; i++)
                {
                    columnAction(i, j);
                }
                rowEndAction(j);
            }
        }

        public StringBuilder EmptyStringBuilder(int width, int height)
            => new StringBuilder(width * height + height * "\r\n".Length);
    }
}
