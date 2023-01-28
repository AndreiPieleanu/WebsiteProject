using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockDAL;
using LogicLayer.Services;
using LogicLayer.LLExceptions;

namespace UnitTests.TestNews
{
    [TestClass]
    public class TestNewsService
    {
        private List<INews> ArrangeNews()
        {
            List<INews> generatedNews;
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews article1 = new Article(1, "Article1", "Subtitle1", daniel, DateTime.Today, NewsCategory.Education, 5, "Article1 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "robotics", "future" });
            INews article2 = new Article(2, "Article2", "Subtitle2", daniel, DateTime.Today, NewsCategory.Entertainment, 5, "Article2 text...", new NormalImage(1, 100.0, 100.0, "imglocation2.png"), new List<string> { "theater", "culture" });
            INews breakingNews1 = new BreakingNews(3, "BreakingNews1", "BreakingNewsSubtitle1", daniel, DateTime.Today.AddDays(-1), NewsCategory.War, 5, "BreakingNews1 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "ukraine", "putin" });
            INews breakingNews2 = new BreakingNews(4, "BreakingNews2", "BreakingNewsSubtitle2", daniel, DateTime.Today.AddDays(-1), NewsCategory.Politics, 5, "BreakingNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "queen", "uk" });
            INews infoNews1 = new InfoNews(5, "InfoNews1", "InfoNews1", daniel, DateTime.Today.AddDays(-1), NewsCategory.Economy, 5, "InfoNews1 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "finance", "money" });
            INews infoNews2 = new InfoNews(6, "InfoNews2", "InfoNews2", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            generatedNews = new List<INews>()
            {
                article1,
                article2,
                breakingNews1,
                breakingNews2,
                infoNews1,
                infoNews2
            };
            return generatedNews;
        }
        [TestMethod]
        public void AddNonExistantNewsToCatalogue_ShouldBe7()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews newsToAdd = new InfoNews(7, "InfoNews3", "InfoNews3", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews3 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.AddNewsToCatalogue(newsToAdd, newsCatalogue);
            int expectedNewsToHave = 7;
            // Assert 
            Assert.AreEqual(expectedNewsToHave, newsCatalogue.AllNews.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(NewsOperationException))]
        public void AddAlreadyExistantNewsWithDifferentIdToCatalogue_ShouldThrowException()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews duplicatedNews = new InfoNews(7, "InfoNews2", "InfoNews2", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.AddNewsToCatalogue(duplicatedNews, newsCatalogue);
            // Assert 
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        [ExpectedException(typeof(NewsOperationException))]
        public void AddAlreadyExistantNewsSameIdToCatalogue_ShouldThrowException()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews duplicatedNews = new InfoNews(6, "InfoNews2", "InfoNews2", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.AddNewsToCatalogue(duplicatedNews, newsCatalogue);
            // Assert 
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        public void EditExistingNewsExistingId_ShouldBeEdited()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews editedExistingNews = new InfoNews(6, "InfoNews4", "InfoNews4", daniel, DateTime.Today, NewsCategory.Economy, 5, "InfoNews4 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.EditNewsFromCatalogue(editedExistingNews, newsCatalogue);
            INews expectedEditedNews = new InfoNews(6, "InfoNews4", "InfoNews4", daniel, DateTime.Today, NewsCategory.Economy, 5, "InfoNews4 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Assert 
            Assert.IsTrue(expectedEditedNews.Equals(newsCatalogue.AllNews[6]));
        }
        [TestMethod]
        [ExpectedException(typeof(NewsOperationException))]
        public void EditNewsWithNonExistingId_ShouldThrowException()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews editedNonExistingNews = new InfoNews(10, "InfoNews2", "InfoNews2", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.EditNewsFromCatalogue(editedNonExistingNews, newsCatalogue);
            // Assert 
            // The code written above is expected to throw an exception
        }
        [TestMethod]
        public void RemoveExistantNewsFromCatalogue_ShouldBe5_CheckIfItIsRemoved()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews existingNewsToRemove = new InfoNews(6, "InfoNews2", "InfoNews2", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews2 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.RemoveNewsFromCatalogue(existingNewsToRemove, newsCatalogue);
            int expectedNewsToHave = 5;
            // Assert 
            Assert.AreEqual(expectedNewsToHave, newsCatalogue.AllNews.Count);
            Assert.IsFalse(newsCatalogue.AllNews.ContainsKey(existingNewsToRemove.Id));
        }
        [TestMethod]
        [ExpectedException(typeof(NewsOperationException))]
        public void RemoveNonExistantNewsFromCatalogue_ShouldThrowException()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            MockNewsDal mockNewsDal = new MockNewsDal();
            NewsService newsService = new NewsService(mockNewsDal, mockNewsDal);
            IUser daniel = new Author(1, new Credentials("tigan@gmail.com", new Password()), new PersonalDetails("Daniel", "Calita"));
            INews nonExistingNewsToRemove = new InfoNews(7, "InfoNews3", "InfoNews3", daniel, DateTime.Today.AddDays(-6), NewsCategory.Economy, 5, "InfoNews3 text...", new NormalImage(1, 100.0, 100.0, "imglocation.png"), new List<string> { "market", "stocks" });
            // Act 
            newsService.RemoveNewsFromCatalogue(nonExistingNewsToRemove, newsCatalogue);
            // Assert 
            // The code written above is expected to throw an exception
        }
    }
}
