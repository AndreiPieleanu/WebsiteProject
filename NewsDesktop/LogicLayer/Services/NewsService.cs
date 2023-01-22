using LogicLayer.DALExceptions;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.LLExceptions;
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
                foreach(INews currentNews in newsCatalogue.AllNews.Values)
                {
                    if (currentNews.Equals(newsToAdd))
                    {
                        throw new NewsOperationException("News that you're trying to add already exists!");
                    }
                }
                if (newsCatalogue.AllNews.ContainsKey(newsToAdd.Id))
                {
                    throw new NewsOperationException("News with this id already exists!");
                }
                _newsDal.AddNewsToCatalogue(newsToAdd, newsCatalogue);
                newsCatalogue.AddNews(newsToAdd);
            }
            catch(DalException ex) {
                throw new TechincalException(ex.Message);
            }
        }

        public void AddTagToNews(string tag, INews news)
        {
            try
            {
                foreach(string newsTag in news.Tags)
                {
                    if (newsTag.Equals(tag))
                    {
                        throw new NewsTagException("You already have this tag in yor news!");
                    }
                }
                _tagDal.AddTagToNews(tag, news);
                news.AddTag(tag);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public void ChangeEditedDateOfNews(DateTime newEditedDate, INews news)
        {
            try
            {
                if(news.EditedDate == newEditedDate)
                {
                    throw new InvalidDateException("Edited date cannot be the same as current edited date!");
                }
                _newsDal.ChangeEditedDateOfNews(newEditedDate, news);
                news.ChangeEditedDate(newEditedDate);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public void EditNewsFromCatalogue(INews updatedNews, NewsCatalogue newsCatalogue)
        {
            try
            {
                foreach (INews currentNews in newsCatalogue.AllNews.Values)
                {
                    if (currentNews.Equals(updatedNews))
                    {
                        throw new NewsOperationException("News with the current edited data already exists!");
                    }
                }
                if (!newsCatalogue.AllNews.ContainsKey(updatedNews.Id))
                {
                    throw new NewsOperationException("News with this id does not exist!");
                }
                _newsDal.EditNewsFromCatalogue(updatedNews, newsCatalogue);
                newsCatalogue.EditNews(updatedNews);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public void EditTagOfNews(string tag, INews news)
        {
            try
            {
                foreach (string newsTag in news.Tags)
                {
                    if (newsTag.Equals(tag))
                    {
                        throw new NewsTagException("You already have this tag in yor news!");
                    }
                }
                _tagDal.EditTagOfNews(tag, news);
                news.EditTag(tag);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public NewsCatalogue GetNewsCatalogue()
        {
            try
            {
                return _newsDal.GetNewsCatalogue();
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public void RemoveNewsFromCatalogue(INews newsToRemove, NewsCatalogue newsCatalogue)
        {
            try
            {
                if (!newsCatalogue.AllNews.ContainsKey(newsToRemove.Id))
                {
                    throw new NewsOperationException("News that you are trying deleting does not exist anymore in the catalogue!");
                }
                _newsDal.RemoveNewsFromCatalogue(newsToRemove, newsCatalogue);
                newsCatalogue.RemoveNews(newsToRemove);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }

        public void RemoveTagFromNews(string tag, INews news)
        {
            try
            {
                bool found = false;
                foreach (string newsTag in news.Tags)
                {
                    if (newsTag.Equals(tag))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new NewsTagException("Tag tha you are trying deleting does not exist!");
                }
                _tagDal.RemoveTagFromNews(tag, news);
                news.RemoveTag(tag);
            }
            catch (DalException ex)
            {
                throw new TechincalException(ex.Message);
            }
        }
    }
}
