using LogicLayer.Enums;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.News
{
    public class NewsCatalogue
    {
        public IReadOnlyDictionary<int, INews> AllNews { get { return new ReadOnlyDictionary<int, INews>(_news); } }
        private Dictionary<int, INews> _news;
        public NewsCatalogue() 
        {
            _news = new Dictionary<int, INews>();
        }
        public void AddNews(INews newsToAdd)
        {
            _news.Add(newsToAdd.Id, newsToAdd);
        }
        public void EditNews(INews newsToEdit)
        {
            if (_news.ContainsKey(newsToEdit.Id))
            {
                _news[newsToEdit.Id] = newsToEdit;
            }
        }
        public void RemoveNews(INews newsToRemove)
        {
            if (_news.ContainsKey(newsToRemove.Id))
            {
                _news.Remove(newsToRemove.Id);
            }
        }
        public List<INews> GetAllNewsOfCategory(NewsCategory category)
        {
            return AllNews.Where(kvp => kvp.Value.Category == category).Select(kvp => kvp.Value).ToList();
        }

        public List<INews> GetAllNewsOfType(NewsType type)
        {
            return AllNews.Where(kvp => kvp.Value.NewsType == type).Select(kvp => kvp.Value).ToList();
        }

        public List<INews> GetAllNewsWithTag(string tag)
        {
            return AllNews.Where(kvp => kvp.Value.Tags.Contains(tag)).Select(kvp => kvp.Value).ToList();
        }
        public List<INews> GetLatestNews()
        {
            return AllNews.Values.OrderByDescending(n => n.CreatedDate).Where(n => n.CreatedDate <= DateTime.Now && n.CreatedDate >= DateTime.Now.AddDays(-5)).ToList();
        }

    }
}
