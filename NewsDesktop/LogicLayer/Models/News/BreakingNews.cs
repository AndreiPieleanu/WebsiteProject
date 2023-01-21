using LogicLayer.Enums;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.News
{
    public class BreakingNews: INews
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
        public IImage? SecondaryImage { get; }
        public IImage? ThirdImage { get; }

        public List<string> Tags { get; }

        public NewsType NewsType { get; }
        public BreakingNews(int id, string title, string subTitle, IUser author, DateTime editedDate, NewsCategory category, int readingTime, string newsText, IImage image, List<string> tags, IImage? secondaryImage = null, IImage? thirdImage = null)
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
            SecondaryImage = secondaryImage;
            Tags = tags;
            NewsType = NewsType.BreakingNews;
            ThirdImage = thirdImage;
        }
        public BreakingNews(string title, string subTitle, IUser author, DateTime editedDate, NewsCategory category, int readingTime, string newsText, IImage image, List<string> tags, IImage? secondaryImage = null, IImage? thirdImage = null)
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
            NewsType = NewsType.BreakingNews;
            SecondaryImage = secondaryImage;
            ThirdImage = thirdImage;
        }

        public void ChangeEditedDate(DateTime newTime)
        {
            EditedDate = newTime;
        }
    }
}
