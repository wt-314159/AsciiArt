// See https://aka.ms/new-console-template for more information
using AsciiArt;
using System.Drawing;
using System.Runtime.Versioning;
using ConsoleHelpers;
using AsciiArt.Properties;
using AsciiArt.AsciiGenerators;
using AsciiArt.AsciiCharacterProviders;
using AsciiArt.Helpers;
using System.Data.SqlTypes;

internal class Program
{
    private const string _functionalityNotImplemented = "Functionality not implemented... yet.";
    private static void Main(string[] args)
    {
        var asciiArtTitle = Resources.AsciiArtScreenshot;
        var asciiProvider = BasicCharacterProvider.HighContrast;
        var titleGen = new BitmapAsciiGenerator();
        var negativeSettings = OutputSettings.FromConsoleSize(true);
        var title = titleGen.GetAsciiArt(asciiArtTitle, asciiProvider, negativeSettings);
        Console.Write(title);
        Console.WriteLine();

        var settings = new MenuSettings(Console.WindowWidth / 2);
        var menu = new Menu<bool>("Main Menu",
            new MenuItem<bool>("Convert Image File", () => ConvertImage()),
            new MenuItem<bool>("Convert Video", NotImplemented),
            new MenuItem<bool>("Adjust Settings", NotImplemented)
            );

        ConsoleApp.LoopProgram(() => menu.Show(settings));
    }

    public static bool ConvertImage()
        => ConsoleApp.LoopProgram(() =>
        {
            Console.WriteLine();
            Console.WriteLine("Enter the path of an image to convert it to ASCII art:");

            var path = ConsoleApp.GetInput(
                x => File.Exists(x?.Trim('"')),
                "File path not valid, please try again.\n");
            path = path?.Trim('"');

            var asciiProvider = BasicCharacterProvider.HighContrast;
            var bmp = new Bitmap(path);
            var bmpGen = new BitmapAsciiGenerator();
            var positiveSettings = OutputSettings.FromConsoleSize(false);
            var art = bmpGen.GetAsciiArt(bmp, asciiProvider, positiveSettings);
            Console.Write(art);

            int zoom = 10;
            while (true)
            {
                var key = Console.ReadKey();
                if (key.KeyChar == '+' || key.KeyChar == '-')
                {
                    bool result = Extensions.SetZoom(ref zoom, key.KeyChar);
                    if (!result) { continue; }
                    var cropWidth = bmp.Width * zoom / 10;
                    var cropHeight = bmp.Height * zoom / 10;
                    var rectangle = new Rectangle(cropWidth, cropHeight, bmp.Width - cropWidth, bmp.Height - cropHeight);
                    var zoomed = bmp.Crop(cropWidth, cropHeight);
                    art = bmpGen.GetAsciiArt(zoomed, asciiProvider, positiveSettings);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write(art);
                }
                else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        },
        "To convert another image, press 'y', or to go back to the main menu, press 'Esc'",
        "");

    private static bool NotImplemented()
    {
        Console.WriteLine(_functionalityNotImplemented);
        return false;
    }
}