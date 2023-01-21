using LogicLayer.Enums;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.News
{
    public class InfoNews : INews
    {
        public int Id { get; }

        public string Title { get; }

        public string SubTitle { get; }

        public IUser Author { get; }

        public DateTime CreatedDate { get; }

        public DateTime EditedDate { get; private set; }

        public NewsCategory Category { get; }

        public int ReadingTime { get; }

        public string NewsText { get; }

        public IImage Image { get; }

        public List<string> Tags { get; }

        public NewsType NewsType { get; }
        public InfoNews(int id, string title, string subTitle, IUser author, DateTime editedDate, NewsCategory category, int readingTime, string newsText, IImage image, List<string> tags)
        {
            Id = id;
            Title = title;
            SubTitle = subTitle;
            Author = author;
            CreatedDate = DateTime.Now;
            EditedDate = editedDate;
            Category = category;
            ReadingTime = readingTime;
            NewsText = newsText;
            Image = image;
            Tags = tags;
            NewsType = NewsType.InfoNews;
        }
        public InfoNews(string title, string subTitle, IUser author, DateTime editedDate, NewsCategory category, int readingTime, string newsText, IImage image, List<string> tags)
        {
            Title = title;
            SubTitle = subTitle;
            Author = author;
            CreatedDate = DateTime.Now;
            EditedDate = editedDate;
            Category = category;
            ReadingTime = readingTime;
            NewsText = newsText;
            Image = image;
            Tags = tags;
            NewsType = NewsType.InfoNews;
        }

        public void ChangeEditedDate(DateTime newTime)
        {
            EditedDate = newTime;
        }
    }
}
