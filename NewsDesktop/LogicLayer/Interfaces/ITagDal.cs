using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface ITagDal
    {
        void AddTagToNews(string tag, INews news);
        void EditTagOfNews(string tag, INews news);
        void RemoveTagFromNews(string tag, INews news);
    }
}
