using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Interfaces;

namespace LogicLayer.Models
{
    public class ThumbnailImage: IImage
    {
        public int Id { get; }
        public double Width { get; }
        public double Height { get; }
        public string ImageLocation { get; }
        public ThumbnailImage(int id, double width, double height, string imageLocation)
        {
            Id = id;
            Width = width;
            Height = height;
            ImageLocation = imageLocation;
        }
        public ThumbnailImage(double width, double height, string imageLocation)
        {
            Width = width;
            Height = height;
            ImageLocation = imageLocation;
        }
    }
}
