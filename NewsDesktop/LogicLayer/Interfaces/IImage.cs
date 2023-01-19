using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IImage
    {
        public int Id { get; }
        public double Width { get; }
        public double Height { get; }
        public string ImageLocation { get; }
    }
}
