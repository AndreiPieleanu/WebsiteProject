using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.LLExceptions;
using LogicLayer.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models.Factories
{
    public class NewsFactory
    {
        public static INews GetNewsChild(INews news)
        {
            switch (news.NewsType)
            {
                case NewsType.BreakingNews:
                    return (BreakingNews)news;
                case NewsType.InfoNews:
                    return (InfoNews)news;
                case NewsType.Articles:
                    return (Article)news;
                default:
                    throw new NewsOperationException("Invalid news type provided!");
            }
        }
    }
}
