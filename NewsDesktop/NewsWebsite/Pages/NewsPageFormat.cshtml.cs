using AspNetCoreHero.ToastNotification.Abstractions;
using LogicLayer.Enums;
using LogicLayer.Interfaces;
using LogicLayer.Models.News;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsWebsite.Pages
{
    public class NewsPageFormatModel : PageModel
    {
        [BindProperty]
        public string SelectedTag { get; set; } = string.Empty;
        public INews SelectedNews { get; set; }
        public Tuple<string, string> NewsTextDivided { get; set; } = new Tuple<string, string>(string.Empty, string.Empty);
        public BreakingNews BreakingNews { get; set; }
        public Article Article { get; set; }
        public InfoNews InfoNews { get; set; }
        private NewsCatalogue _newsCatalogue = new NewsCatalogue();
        private readonly INotyfService _toastNotification;
        private NewsService _newsService;
        public NewsPageFormatModel(INotyfService toastNotification, NewsService newsService)
        {
            _toastNotification = toastNotification;
            _newsService = newsService;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                _newsCatalogue = _newsService.GetNewsCatalogue();
                if (!_newsCatalogue.AllNews.ContainsKey(id)) return BadRequest("Invalid id provided!");
                SelectedNews = _newsCatalogue.AllNews[id];
                NewsTextDivided = SelectedNews.BreakTextIn2EqualHalves();
                if (SelectedNews.NewsType == NewsType.InfoNews)
                {
                    InfoNews = (InfoNews)SelectedNews;
                }
                else if(SelectedNews.NewsType == NewsType.Articles)
                {
                    Article = (Article)SelectedNews;
                }
                else
                {
                    BreakingNews = (BreakingNews)SelectedNews;
                }
            }
            catch(Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
            return Page();
        }
        public IActionResult OnPostGetTag()
        {
            return RedirectToPage("/Index", new { tag = SelectedTag });
        }
    }
}
