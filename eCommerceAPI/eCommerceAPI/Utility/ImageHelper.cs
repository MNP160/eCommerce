using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Utility
{
    public class ImageHelper
    {
        public enum ImageFormats
        {
            png,
            jpeg,
            unknown
        }

        public static ImageFormats GetImageFormat(byte[] bytes)
        {
            var png = new byte[] { 137, 80, 78, 71 };
            var jpeg = new byte[] { 255, 216, 255, 224 };          
            var jpeg2 = new byte[] { 255, 216, 255, 225 };

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormats.png;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormats.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormats.jpeg;

            return ImageFormats.unknown;
        }

    }
}
