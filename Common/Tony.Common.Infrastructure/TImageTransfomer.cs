using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Tony.Common.Infrastructure
{
    public class ImageTransfomer
    {
        //cropping image
        public static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        //getting gray scale of an image
        public static Bitmap GetGrayScale(Bitmap Bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return Bmp;
        }

        //scaling image
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public static byte[] GetByteArrayFromImage(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            ImageFormat format = imageIn.RawFormat;
            imageIn.Save(ms, format); 
            return ms.ToArray();
        }

        public static byte[] ImageToByteArray(Image imageIn, string ext)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                ImageFormat format = ImageFormat.Gif;
                switch (ext.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case "png":
                        format = ImageFormat.Png;
                        break;
                    case "gif":
                        format = ImageFormat.Gif;
                        break;
                    case "bmp":
                        format = ImageFormat.Bmp;
                        break;
                    default:
                        format = imageIn.RawFormat;
                        break;

                }
                imageIn.Save(ms, format);
                return ms.ToArray();
            }
            catch
            {
                try
                {
                    return GetByteArrayFromImage(imageIn);
                }
                catch
                {
                    return null;
                }
            }
        
        }
       
    
    }
}
