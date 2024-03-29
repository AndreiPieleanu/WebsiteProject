﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Enums;

namespace LogicLayer.Interfaces
{
    public interface INews
    {
        public int Id { get; }
        public string Title { get; }
        public string SubTitle { get; }
        public IUser Author { get; }
        public DateTime CreatedDate { get; }
        public DateTime EditedDate { get; }
        public NewsCategory Category { get; }
        public int ReadingTime { get; }
        public string NewsText { get; }
        public IImage Image { get; }
        public List<string> Tags { get; }
        public NewsType NewsType { get; }

        public void AddTag(string tag)
        {
            Tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            if(Tags.Contains(tag)) 
                Tags.Remove(tag);
        }

        public void EditTag(string tag)
        {
            for (int i = 0; i < Tags.Count; i++)
            {
                if (Tags[i].Equals(tag))
                {
                    Tags[i] = tag;
                    return;
                }
            }
        }
        public void ChangeEditedDate(DateTime newTime);
        public bool Equals(INews news)
        {
            return news.Title.Equals(Title) && news.SubTitle.Equals(SubTitle) && news.Author.Equals(Author) && news.CreatedDate.Date.Equals(CreatedDate.Date) && news.NewsText.Equals(NewsText) && news.ReadingTime == ReadingTime && news.Category == Category && news.NewsType == NewsType;
        }
        public Tuple<string, string> BreakTextIn2EqualHalves()
        {
            string[] newsTextDivided = NewsText.Split(".");
            string half1 = string.Empty;
            string half2 = string.Empty;
            for(int i = 0; i < newsTextDivided.Length / 2; i++)
            {
                half1 = half1 + newsTextDivided[i] + ". ";
            }
            for(int i = newsTextDivided.Length / 2; i < newsTextDivided.Length; i++)
            {
                half2 = half2 + newsTextDivided[i] + ". ";
            }
            return new Tuple<string, string>(half1, half2);
        }
    }
}
