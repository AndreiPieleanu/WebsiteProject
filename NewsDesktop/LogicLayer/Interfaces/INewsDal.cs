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
        NewsCatalogue GetAllNews();
        List<INews> GetAllNewsOfCategoryFromCatalogue(NewsCategory category, NewsCatalogue newsCatalogue);
        List<INews> GetAllNewsOfTypeFromCatalogue(NewsType type, NewsCatalogue newsCatalogue);
        List<INews> GetAllNewsWithTagFromCatalogue(string tag, NewsCatalogue newsCatalogue);
        void ChangeEditedDateOfNews(DateTime newEditedDate, INews news);

    }
}
