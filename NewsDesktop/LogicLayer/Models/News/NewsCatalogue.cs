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

    }
}
