using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Watermarker.Models;
using System.Runtime.InteropServices;

namespace Watermarker
{
    public static class ImageUtilities
    {
        /// <summary>
        /// Put the selected watermark covering the entire image
        /// </summary>
        /// <param name="ImagePath">Path of the image to watermark</param>
        /// <param name="WaterMarkString">Watermark text</param>
        /// <param name="DestinationPath">Path where the result image will be storaged</param>
        /// <param name="size">Size of the font</param>
        public static void setWatermarkText( string ImagePath, string WaterMarkString, string DestinationPath, int size)
        { 
            Image image = Image.FromFile(ImagePath);
            int imgWidth = image.Width;
            int imgHeight = image.Height;
            Bitmap imagebtm = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            imagebtm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(imagebtm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            Font font = new Font("arial", size, FontStyle.Bold);
            SolidBrush b2 = new SolidBrush(Color.FromArgb(120, 255, 255, 255));
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            for (int y = 0; y < imgHeight; y += 70)
            {
                for (int x = 0; x < imgWidth; x += size * WaterMarkString.Length)
                {

                    g.DrawString(WaterMarkString, font, b2, new PointF(x, y), format);
                }
            }
            g.Dispose();

            imagebtm.Save(DestinationPath);
        }

        /// <summary>
        /// Put the watermark text in a selected location of the image
        /// </summary>
        /// <param name="style">Define the location of the watermark</param>
        /// <param name="ImagePath">Path of the image to watermark</param>
        /// <param name="WaterMarkString">Watermark text</param>
        /// <param name="DestinationPath">Path where the result image will be storaged</param>
        /// <param name="size">Size of the font</param>
        public static void setWatermarkText(WatermarkStyle style, string ImagePath, string WaterMarkString, string DestinationPath, int size)
        {
            Image image = Image.FromFile(ImagePath);
            int imgWidth = image.Width;
            int imgHeight = image.Height;
            Bitmap imagebtm = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            imagebtm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(imagebtm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            Font font = new Font("arial", size, FontStyle.Bold);
            
            var fontSize = LocationLogic.GetFontSize(font, WaterMarkString);
            var location = LocationLogic.Calutate(style, imgWidth, imgHeight, fontSize.Width, size);
            int xPos = location[0];
            int yPos = location[1];

            SolidBrush b2 = new SolidBrush(Color.FromArgb(120, 255, 255, 255));
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            

            g.DrawString(WaterMarkString, font, b2, new PointF(xPos, yPos), format);
                
            g.Dispose();

            imagebtm.Save(DestinationPath);


        }

        /// <summary>
        /// Put the watermark image in a selected location of the image
        /// </summary>
        /// <param name="BaseImagePath">Path of the image to watermark</param>
        /// <param name="WaterMarkImage">Path of the watermark image</param>
        /// <param name="DestinationPath">Path where the result image will be storaged</param>
        public static void setWatermarkImage(WatermarkStyle style, string BaseImagePath, string WaterMarkImage, string DestinationPath)
        {
            Image image = Image.FromFile(BaseImagePath);
            Image wmImage = Image.FromFile(WaterMarkImage);
            int imgWidth = image.Width;
            int imgHeight = image.Height;
            Bitmap imagebtm = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            imagebtm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(imagebtm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            ImageAttributes imageAttributes =
                           new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable,
                                     ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {
               new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
               new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
               new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
               new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
               new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
            };

            ColorMatrix wmColorMatrix = new
                            ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(wmColorMatrix,
                                   ColorMatrixFlag.Default,
                                     ColorAdjustType.Bitmap);
            var location = LocationLogic.Calutate(style, new ImageModel(imgWidth, imgHeight ), new ImageModel(wmImage.Width, wmImage.Height));
            int xPos = location[0];
            int yPos = location[1];

            SolidBrush b2 = new SolidBrush(Color.FromArgb(120, 255, 255, 255));
            g.DrawImage(wmImage,
                 new Rectangle(xPos, yPos, wmImage.Width,wmImage.Height),
                 0,
                 0,
                 wmImage.Width, 
                 wmImage.Height,
                 GraphicsUnit.Pixel,
                 imageAttributes);

            g.Dispose();

            imagebtm.Save(DestinationPath);


        }
        /// <summary>
        /// Put the selected watermark covering the entire image
        /// </summary>
        /// <param name="BaseImagePath">Path of the image to watermark</param>
        /// <param name="WaterMarkImage">Path of the watermark image</param>
        /// <param name="DestinationPath">Path where the result image will be storaged</param>

        public static void setWatermarkImage( string BaseImagePath, string WaterMarkImage, string DestinationPath)
        {
            Image image = Image.FromFile(BaseImagePath);
            Image wmImage = Image.FromFile(WaterMarkImage);
            int imgWidth = image.Width;
            int imgHeight = image.Height;
            Bitmap imagebtm = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            imagebtm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(imagebtm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, imgWidth, imgHeight, GraphicsUnit.Pixel);
            ImageAttributes imageAttributes =
                           new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable,
                                     ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {
               new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
               new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
               new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
               new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
               new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
            };

            ColorMatrix wmColorMatrix = new
                            ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(wmColorMatrix,
                                   ColorMatrixFlag.Default,
                                     ColorAdjustType.Bitmap);
           

            SolidBrush b2 = new SolidBrush(Color.FromArgb(120, 255, 255, 255));

            int countHorizontal = (int)Math.Ceiling((double)imgWidth / (wmImage.Width + 10));
            int totalSizeH = countHorizontal * (wmImage.Width + 10) - 10;
            int startPointX = (imgWidth-totalSizeH) / 2;
            int countVertical = (int)Math.Ceiling((double)imgHeight / (wmImage.Height + 10));
            int totalSizeV = countVertical * (wmImage.Height + 10) - 10;
            int startPointY = (imgHeight - totalSizeV) / 2;
            for (int x = startPointX; x <= imgWidth; x+= wmImage.Width + 10)
            {
                for(int y = startPointY; y <= imgHeight; y += wmImage.Height + 10)
                {
                    g.DrawImage(wmImage,
                new Rectangle(x, y, wmImage.Width, wmImage.Height),
                0,
                0,
                wmImage.Width,
                wmImage.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
                }
            }
           

            g.Dispose();

            imagebtm.Save(DestinationPath);


        }

        /// <summary>
        /// Resize a given image
        /// </summary>
        /// <param name="ImagePath">Path of the image to resize</param>
        /// <param name="perCent">How much the image will be resized</param>
        /// <param name="DestinationPath">Path where the result image will be storaged</param>
        public static void Resize(string ImagePath, int perCent, string DestinationPath)
        {
            Image image = Image.FromFile(ImagePath);
            int imgWidth = (int)(image.Width * (double)perCent / 100);
            int imgHeight = (int)(image.Height * (double)perCent / 100);
            Bitmap imagebtm = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(imagebtm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(image, new Rectangle(0, 0, imgWidth, imgHeight), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            g.Dispose();
            imagebtm.Save(DestinationPath);
        }

        public static int GetWidth(string ImagePath)
        {
            Image image = Image.FromFile(ImagePath);
            return (int)image.Width;
        }

        public static int GetHeight(string ImagePath)
        {
            Image image = Image.FromFile(ImagePath);
            return (int)image.Height;
        }
    }
}
