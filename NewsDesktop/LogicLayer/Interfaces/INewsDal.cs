using LogicLayer.Enums;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface INewsDal
    {
        void AddNewsToCatalogue(INews newsToAdd, NewsCatalogue newsCatalogue);
        void EditNewsFromCatalogue(INews updatedNews, NewsCatalogue newsCatalogue);
        void RemoveNewsFromCatalogue(INews newsToRemove, NewsCatalogue newsCatalogue);
        NewsCatalogue GetNewsCatalogue();
        List<NewsCategory> GetNewsCategories();
        void ChangeEditedDateOfNews(DateTime newEditedDate, INews news);

    }
}
