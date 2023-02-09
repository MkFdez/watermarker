using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarker.Models
{
    public class ImageModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ImageModel(int width, int height)
        {
            Width = width;
            Height = height;
        }   
    }
}
