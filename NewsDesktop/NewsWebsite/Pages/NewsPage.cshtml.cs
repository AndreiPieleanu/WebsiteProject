using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsWebsite.Pages
{
    public class NewsPageModel : PageModel
    {
        private NewsCatalogue NewsCatalogue { get; set; } = new NewsCatalogue();
        public List<INews> AllNews { get; set; } = new List<INews>();
        public INews FirstNews { get; set; }
        private readonly INotyfService _toastNotification;
        private NewsService _newsService;
        public NewsPageModel(INotyfService toastNotification, NewsService newsService)
        {
            _toastNotification = toastNotification;
            _newsService = newsService;
        }
        public void OnGet()
        {
            try
            {
                NewsCatalogue = _newsService.GetNewsCatalogue();
                AllNews = NewsCatalogue.GetAllNewsOfType(NewsType.Articles);
                if (AllNews.Count > 0)
                    FirstNews = AllNews.First();
            }
            catch (ArgumentNullException)
            {
                _toastNotification.Error("No news found!");
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
        }
    }
}
