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
    Console.ReadLine();
});
