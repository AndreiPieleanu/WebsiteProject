using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.LLExceptions;
using LogicLayer.Models;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestNews
{
    [TestClass]
    public class TestNewsCatalogue
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
        public void FindAllEconomicNews_ShouldBe2()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach(INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            NewsCategory economics = NewsCategory.Economy;
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsOfCategory(economics);
            int expectedEconomicNews = 2;
            // Assert 
            Assert.AreEqual(expectedEconomicNews, result.Count);
        }
        [TestMethod]
        public void FindAllCanCanNews_ShouldBeNone()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            NewsCategory cancan = NewsCategory.Cancan;
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsOfCategory(cancan);
            int expectedCanCanNews = 0;
            // Assert 
            Assert.AreEqual(expectedCanCanNews, result.Count);
        }
        [TestMethod]
        public void GetAllArticles_ShouldBe2()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            NewsType articleNews = NewsType.Articles;
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsOfType(articleNews);
            int expectedArticleNews = 2;
            // Assert 
            Assert.AreEqual(expectedArticleNews, result.Count);
        }
        [TestMethod]
        public void GetAllBreakingNews_ShouldBe2()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            NewsType breakingNews = NewsType.BreakingNews;
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsOfType(breakingNews);
            int expectedBreakingNews = 2;
            // Assert 
            Assert.AreEqual(expectedBreakingNews, result.Count);
        }
        [TestMethod]
        public void GetAllNewsWithExistingTag()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            string existingTag = "uk";
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsWithTag(existingTag);
            int expectedNewsWithThisTag = 1;
            // Assert 
            Assert.AreEqual(expectedNewsWithThisTag, result.Count);
        }
        [TestMethod]
        public void GetAllNewsWithNonExistingTag_ShouldReturn0()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            string nonExistingTag = "tesla";
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsWithTag(nonExistingTag);
            int expectedNewsWithThisTag = 0;
            // Assert 
            Assert.AreEqual(expectedNewsWithThisTag, result.Count);
        }
        [TestMethod]
        public void GetLatestNews_ShouldBe6()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            // Act 
            List<INews> result = newsCatalogue.GetLatestNews();
            int expectedLatestNews = 6;
            // Assert 
            Assert.AreEqual(expectedLatestNews, result.Count);
        }
        [TestMethod]
        public void SearchNewsWithExistingText_ShouldReturnGreatherThan0()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            string validText = "uk";
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsWhichContainText(validText);
            // Assert 
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void SearchNewsWithInexistingText_ShouldReturnNoElements()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            string nonExistantText = "ssdfeqa";
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsWhichContainText(nonExistantText);
            // Assert 
            Assert.IsTrue(result.Count == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(NewsOperationException))]
        public void SearchNewsWithInvalidText_ShouldReturnGreatherThan0()
        {
            // Arrange
            NewsCatalogue newsCatalogue = new NewsCatalogue();
            foreach (INews news in ArrangeNews())
            {
                newsCatalogue.AddNews(news);
            }
            string invalidText = null;
            // Act 
            List<INews> result = newsCatalogue.GetAllNewsWhichContainText(invalidText);
            // Assert 
            // The code written above is expected to throw an exception
        }
    }
}
