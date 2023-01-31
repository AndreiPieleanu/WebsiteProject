using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DALs
{
    public class TagDal : BaseDal, ITagDal
    {
        public TagDal(DbSettings settings) : base(settings)
        {
        }

        public void AddTagToNews(string tag, INews news)
        {
            throw new NotImplementedException();
        }

        public void EditTagOfNews(string tag, INews news)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromNews(string tag, INews news)
        {
            throw new NotImplementedException();
        }
    }
}
