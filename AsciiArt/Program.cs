// See https://aka.ms/new-console-template for more information
using AsciiArt;
using System.Drawing;
using System.Runtime.Versioning;

var path = Console.ReadLine();
path = path?.Trim('"');
if (path == null)
{
    path = Console.ReadLine();
}
var bmp = new Bitmap(path);
//var bmpGen = new BitmapAsciiGenerator(
//    "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,\"^`'.",
//    x => x.Grayscale());
var bmpGen = new BitmapAsciiGenerator();
var art = bmpGen.GetAsciiArt(bmp, Console.WindowWidth, (int)Console.WindowHeight);
Console.Write(art);
Console.SetCursorPosition(0, 0);
Console.ReadLine();