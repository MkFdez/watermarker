using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarker.Models;


namespace Watermarker
{
    public static class LocationLogic
    {
        /// <summary>
        /// return an array with the x and y position of where the text is going to be
        /// </summary>
        public static int[] Calutate(WatermarkStyle style, int imgW, int imgH, int textW, int textH)
        {
            switch (style)
            {
                case WatermarkStyle.Center:
                    return Positions.Center(imgW, imgH, textW, textH);
                case WatermarkStyle.TopCenter:
                    return Positions.CenterTop(imgW, imgH, textW);
                case WatermarkStyle.BottomCenter:
                    return Positions.CenterBottom(imgW, imgH, textW, textH);
                case WatermarkStyle.LeftCenter:
                    return Positions.LeftCenter(imgW, imgH, textH, textW);
                case WatermarkStyle.RightCenter:
                    return Positions.RightCenter(imgW, imgH, textW, textH);
                case WatermarkStyle.LeftTop:
                    return Positions.LeftTop(imgW, imgH, textW);
                case WatermarkStyle.RightTop:
                    return Positions.RightTop(imgW, imgH, textW);
                case WatermarkStyle.LeftBottom:
                    return Positions.LeftBottom(imgW, imgH, textH, textW);
                case WatermarkStyle.RightBottom:
                    return Positions.RightBottom(imgW, imgH, textW, textH);                    
            }
            return new int[] {0,0};
        }

        public static int[] Calutate(WatermarkStyle style, ImageModel baseImg, ImageModel wmImg)
        {
            switch (style)
            {
                case WatermarkStyle.Center:
                    return Positions.Center(baseImg, wmImg);
                case WatermarkStyle.TopCenter:
                    return Positions.CenterTop(baseImg, wmImg);
                case WatermarkStyle.BottomCenter:
                    return Positions.CenterBottom(baseImg, wmImg);
                case WatermarkStyle.LeftCenter:
                    return Positions.LeftCenter(baseImg, wmImg);
                case WatermarkStyle.RightCenter:
                    return Positions.RightCenter(baseImg, wmImg);
                case WatermarkStyle.LeftTop:
                    return Positions.LeftTop();
                case WatermarkStyle.RightTop:
                    return Positions.RightTop(baseImg, wmImg);
                case WatermarkStyle.LeftBottom:
                    return Positions.LeftBottom(baseImg, wmImg);
                case WatermarkStyle.RightBottom:
                    return Positions.RightBottom(baseImg, wmImg);
            }
            return new int[] { 0, 0 };
        }


        public static FontModel GetFontSize(Font stringFont, string measureString)
        {
            SizeF stringSize = new SizeF();
            Graphics gfx = Graphics.FromImage(new Bitmap(1, 1));
            stringSize = gfx.MeasureString(measureString, stringFont);
            return new FontModel((int)stringSize.Width, (int)stringSize.Height);
            
        }
    }
}
