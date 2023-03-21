// See https://aka.ms/new-console-template for more information
using AsciiArt;
using System.Drawing;
using System.Runtime.Versioning;

var path = @"C:\Users\User\Downloads\cat.jfif";
var bmp = new Bitmap(path);
var bmpGen = new BitmapAsciiGenerator();
var art = bmpGen.GetAsciiArt(bmp, Console.WindowWidth);
Console.Write(art);
Console.SetCursorPosition(0, 0);
Console.ReadLine();