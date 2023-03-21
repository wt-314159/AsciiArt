// See https://aka.ms/new-console-template for more information
using AsciiArt;
using System.Drawing;
using System.Runtime.Versioning;
using ConsoleHelpers;
using AsciiArt.Properties;

var asciiArtTitle = Resources.AsciiArtScreenshot;
var titleGen = new BitmapAsciiGenerator();
var title = titleGen.GetAsciiArt(asciiArtTitle, Console.WindowWidth, Console.WindowHeight, true);
Console.Write(title);
Console.WriteLine();

ConsoleApp.LoopProgram(() =>
{
    Console.WriteLine();
    Console.WriteLine("Enter the path of an image to convert it to ASCII art:");

    var path = ConsoleApp.GetInput(
        x => !File.Exists(x?.Trim('"')),
        "File path not valid, please try again.\n");
    path = path?.Trim('"');

    var bmp = new Bitmap(path);
    var bmpGen = new BitmapAsciiGenerator();
    var art = bmpGen.GetAsciiArt(bmp, Console.WindowWidth, Console.WindowHeight);
    Console.Write(art);

    while (true)
    {
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
        {
            break;
        }
        else if (key.KeyChar == '+')
        {
            var cropWidth = bmp.Width / 10;
            var cropHeight = bmp.Height / 10;
            var rectangle = new Rectangle(cropWidth, cropHeight, bmp.Width - cropWidth, bmp.Height - cropHeight);
            var zoomed = bmp.Clone(rectangle, bmp.PixelFormat);
            art = bmpGen.GetAsciiArt(zoomed, Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(art);
        }
    }

});
