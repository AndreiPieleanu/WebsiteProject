using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class NewsService
    {
        private INewsDal _newsDal;
        private ITagDal _tagDal;
        public NewsService(INewsDal newsDal, ITagDal tagDal)
        {
            _newsDal = newsDal;
            _tagDal = tagDal;
        }
        public void AddNewsToCatalogue(INews newsToAdd, NewsCatalogue newsCatalogue)
        {
            try
            {
                _newsDal.AddNewsToCatalogue(newsToAdd, newsCatalogue);
                newsCatalogue.AddNews(newsToAdd);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void AddTagToNews(string tag, INews news)
        {
            try
            {
                _tagDal.AddTagToNews(tag, news);
                news.AddTag(tag);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangeEditedDateOfNews(DateTime newEditedDate, INews news)
        {
            try
            {
                _newsDal.ChangeEditedDateOfNews(newEditedDate, news);
                news.ChangeEditedDate(newEditedDate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditNewsFromCatalogue(INews updatedNews, NewsCatalogue newsCatalogue)
        {
            try
            {
                _newsDal.EditNewsFromCatalogue(updatedNews, newsCatalogue);
                newsCatalogue.EditNews(updatedNews);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditTagOfNews(string tag, INews news)
        {
            try
            {
                _tagDal.EditTagOfNews(tag, news);
                news.EditTag(tag);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public NewsCatalogue GetAllNews()
        {
            try
            {
                return _newsDal.GetAllNews();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<INews> GetAllNewsOfCategoryFromCatalogue(NewsCategory category, NewsCatalogue newsCatalogue)
        {
            try
            {
                return newsCatalogue.AllNews.Where(kvp => kvp.Value.Category == category).Select(kvp => kvp.Value).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<INews> GetAllNewsOfTypeFromCatalogue(NewsType type, NewsCatalogue newsCatalogue)
        {
            try
            {
                return newsCatalogue.AllNews.Where(kvp => kvp.Value.NewsType == type).Select(kvp => kvp.Value).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<INews> GetAllNewsWithTagFromCatalogue(string tag, NewsCatalogue newsCatalogue)
        {
            try
            {
                return newsCatalogue.AllNews.Where(kvp => kvp.Value.Tags.Contains(tag)).Select(kvp => kvp.Value).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveNewsFromCatalogue(INews newsToRemove, NewsCatalogue newsCatalogue)
        {
            try
            {
                _newsDal.RemoveNewsFromCatalogue(newsToRemove, newsCatalogue);
                newsCatalogue.RemoveNews(newsToRemove);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveTagFromNews(string tag, INews news)
        {
            try
            {
                _tagDal.RemoveTagFromNews(tag, news);
                news.RemoveTag(tag);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
