using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsWebsite.Pages
{
    public class IndexModel : PageModel
    {
        public NewsCatalogue NewsCatalogue { get; set; } = new NewsCatalogue();
        public BreakingNews BreakingNews { get; set; }
        private readonly INotyfService _toastNotification;
        private NewsService _newsService;
        public IndexModel(INotyfService toastNotification, NewsService newsService)
        {
            _toastNotification = toastNotification;
            _newsService = newsService;
        }
        public void OnGet()
        {
            try
            {
                NewsCatalogue = _newsService.GetNewsCatalogue();
                BreakingNews = (BreakingNews)NewsCatalogue.AllNews.Where(n => n.Value.NewsType == NewsType.BreakingNews).First().Value;
            }
            catch(Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
        }
    }
}