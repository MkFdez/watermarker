using Watermarker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarker
{
    public static class Positions
    {
        //left section
        public static int[] LeftTop(int imgW, int imgH, int textW)
        {
            int x = 2 + (textW - (int)(textW * 0.20)) / 2; ;
            int y = 2;
            return new int[] { x, y };
        }
        public static int[] LeftTop()//For images
        {
            int x = 10 ;
            int y = 10;
            return new int[] { x, y };
        }
        public static int[] LeftCenter(int imgW, int imgH, int textH, int textW)
        {
            int x = 2+ (textW - (int)(textW * 0.20)) /2;
            int y = (imgH / 2) - (textH / 2) - (int)(textH * 0.15);
            return new int[] { x, y };
        }
        public static int[] LeftCenter(ImageModel baseImg, ImageModel wmImg)//For images
        {
            int x = 10;
            int y = (baseImg.Height / 2) - (wmImg.Height / 2) ;
            return new int[] { x, y };
        }
        public static int[] LeftBottom(int imgW, int imgH, int textH, int textW)
        {
            int x = 2 + (textW - (int)(textW * 0.20)) / 2; ;
            int y = imgH - textH - 2 - (int)(textH * 0.15);
            return new int[] { x, y };
        }

        public static int[] LeftBottom(ImageModel baseImg, ImageModel wmImg)//For images
        {
            int x = 10;
            int y = baseImg.Height - wmImg.Height - 10;
            return new int[] { x, y };
        }

        //center section
        public static int[] CenterTop(int imgW, int imgH, int textW)
        {
            int x = (imgW)/2;
            int y = 2;
            return new int[] { x, y };
        }

        public static int[] CenterTop(ImageModel baseImg, ImageModel wmImg) //For images
        {
            int x = baseImg.Width/ 2  -  wmImg.Width/2;
            int y = 10;
            return new int[] { x, y };
        }
        public static int[] Center(int imgW, int imgH, int textW, int textH)
        {
            int x = (imgW) / 2;
            int y = (imgH / 2)-(textH/2)- (int)(textH * 0.15);
            return new int[] { x, y };
        }

        public static int[] Center(ImageModel baseImg, ImageModel wmImg) //For images
        {
            int x = baseImg.Width / 2 - wmImg.Width / 2;
            int y = (baseImg.Height / 2) - (wmImg.Height / 2);
            return new int[] { x, y };
        }

        public static int[] CenterBottom(int imgW, int imgH, int textW, int textH)
        {
            int x =  (imgW) / 2;
            int y = imgH - textH - 2 - (int)(textH * 0.15);
            return new int[] { x, y };
        }

        public static int[] CenterBottom(ImageModel baseImg, ImageModel wmImg) //For images
        {
            int x = baseImg.Width / 2 - wmImg.Width / 2; ;
            int y = baseImg.Height - wmImg.Height - 10;
            return new int[] { x, y };
        }
        //right section
        public static int[] RightTop(int imgW, int imgH, int textW)
        {
            int x = (imgW - (textW - (int)(textW * 0.20)) / 2) + 2;
            int y = 2;
            return new int[] { x, y };
        }

        public static int[] RightTop(ImageModel baseImg, ImageModel wmImg) // For images
        {
            int x = baseImg.Width-wmImg.Width-10;
            int y = 10;
            return new int[] { x, y };
        }
        public static int[] RightCenter(int imgW, int imgH, int textW, int textH)
        {
            int x = (imgW - (textW - (int)(textW * 0.20)) / 2) + 2;
            int y = (imgH / 2) - (textH / 2) - (int)(textH * 0.15);
            return new int[] { x, y };
        }

        public static int[] RightCenter(ImageModel baseImg, ImageModel wmImg) //For images
        {
            int x = baseImg.Width - wmImg.Width - 10;
            int y = (baseImg.Height / 2) - (wmImg.Height / 2);
            return new int[] { x, y };
        } 
        public static int[] RightBottom(int imgW, int imgH, int textW, int textH)
        {
            int x = (imgW - (textW - (int)(textW * 0.20)) / 2) + 2;
            int y = imgH - textH - 2 - (int)(textH * 0.15);
            return new int[] { x, y };
        }

        public static int[] RightBottom(ImageModel baseImg, ImageModel wmImg) //For images
        {
            int x = baseImg.Width - wmImg.Width - 10;
            int y = baseImg.Height - wmImg.Height - 10;
            return new int[] { x, y };
        }
    }
}
