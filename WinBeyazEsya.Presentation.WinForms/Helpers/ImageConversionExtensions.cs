using System.Drawing.Imaging;
using System.IO;

namespace WinBeyazEsya.Presentation.WinForms.Helpers
{
    public static class ImageConversionExtensions
    {
        public static Image? ToImage(this byte[]? byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using var ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }

        public static byte[]? ToByteArray(this Image? image)
        {
            if (image == null) return null;
            using var ms = new MemoryStream();

            ImageFormat format = ImageFormat.Png; // Default to PNG for transparency and lossless
            if (image.RawFormat != null && !image.RawFormat.Guid.Equals(ImageFormat.MemoryBmp.Guid))
            {
                format = image.RawFormat;
            }

            image.Save(ms, format);
            return ms.ToArray();
        }
    }
}

