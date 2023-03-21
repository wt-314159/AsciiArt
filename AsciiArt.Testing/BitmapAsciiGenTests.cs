using System.Drawing;
using System.Runtime.Versioning;

namespace AsciiArt.Testing
{
    [TestClass]
    public class BitmapAsciiGenTests
    {
        [TestMethod]
        public void ConstructorsTest()
        {
            var bmpGen = new BitmapAsciiGenerator();
            Assert.IsNotNull(bmpGen);

            var testString = "hello world!";
            var testInt = 69420;
            var bmpGen2 = new BitmapAsciiGenerator(testString, x => testInt);
            Assert.IsNotNull(bmpGen2);
            Assert.AreEqual(testString, bmpGen2.OrderedAsciiSet);
            Assert.AreEqual(testInt, bmpGen2.GetPixelValue(Color.Black));
        }

        [TestMethod]
        public void GetAsciiTest()
        {
            var bmp = new Bitmap(16,9);
            var bmpGen = new BitmapAsciiGenerator();
            bmpGen.GetAsciiArt(bmp);
        }
    }
}