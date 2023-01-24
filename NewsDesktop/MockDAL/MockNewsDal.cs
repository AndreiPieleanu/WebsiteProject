using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDAL
{
    public class MockNewsDal : INewsDal, ITagDal
    {
        public void AddNewsToCatalogue(INews newsToAdd, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void AddTagToNews(string tag, INews news)
        {
            return;
        }

        public void ChangeEditedDateOfNews(DateTime newEditedDate, INews news)
        {
            return;
        }

        public void EditNewsFromCatalogue(INews updatedNews, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void EditTagOfNews(string tag, INews news)
        {
            return;
        }
        public NewsCatalogue NewsCatalogue { get; set; } = new NewsCatalogue();
        public NewsCatalogue GetNewsCatalogue()
        {
            return NewsCatalogue;
        }
        public void RemoveNewsFromCatalogue(INews newsToRemove, NewsCatalogue newsCatalogue)
        {
            return;
        }

        public void RemoveTagFromNews(string tag, INews news)
        {
            return;
        }

        
    }
}
