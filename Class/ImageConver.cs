using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SmartSorage.Class
{
    public static class ImageConver
    {
        public static byte[] ConvertToByte(Bitmap ImageConvert)
        {
            using(MemoryStream Stream = new MemoryStream())
            {
                ImageConvert.Save(Stream, ImageFormat.Jpeg);
                return Stream.ToArray();
            }
        }
    }
}
