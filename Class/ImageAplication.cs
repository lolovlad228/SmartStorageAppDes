using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace SmartSorage.Class
{
    public static class ImageAplication
    {
        public static byte[] ConvertToByte(Bitmap ImageConvert)
        {
            using(MemoryStream Stream = new MemoryStream())
            {
                ImageConvert.Save(Stream, ImageFormat.Jpeg);
                return Stream.ToArray();
            }
        }

        public static byte[] ConvertToByte(Bitmap ImageConvert, ImageFormat format)
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                ImageConvert.Save(Stream, format);
                return Stream.ToArray();
            }
        }

        public static byte[] GenerateQrCode(string QrCode, int Size)
        {
            QRCodeGenerator GoodsQrCode = new QRCodeGenerator();
            QRCodeData qRCodeData = GoodsQrCode.CreateQrCode(QrCode, QRCodeGenerator.ECCLevel.Q);
            QRCode GoodsCode = new QRCode(qRCodeData);
            return ImageAplication.ConvertToByte(GoodsCode.GetGraphic(Size));
        }
    }
}
