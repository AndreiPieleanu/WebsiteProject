﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
        private NewsCatalogue NewsCatalogue { get; set; } = new NewsCatalogue();
        public List<INews> AllNews { get; set; } = new List<INews>();
        public INews FirstNews { get; set; }
        private readonly INotyfService _toastNotification;
        private NewsService _newsService;
        public IndexModel(INotyfService toastNotification, NewsService newsService)
        {
            _toastNotification = toastNotification;
            _newsService = newsService;
        }
        public void OnGet(string? tag)
        {
            try
            {
                NewsCatalogue = _newsService.GetNewsCatalogue();
                if (string.IsNullOrEmpty(tag))
                {
                    AllNews = NewsCatalogue.AllNews.Values.ToList();
                }
                else
                {
                    AllNews = NewsCatalogue.GetAllNewsWithTag(tag);
                }
                if(AllNews.Count > 0)
                    FirstNews = AllNews.First();
            }
            catch(ArgumentNullException)
            {
                _toastNotification.Error("No news found!");
            }
            catch(Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
        }
        public void OnPost()
        {
            try
            {
                NewsCatalogue = _newsService.GetNewsCatalogue();
                var searchString = Request.Form["searchString"];
                AllNews = NewsCatalogue.GetAllNewsWhichContainText(searchString.ToString());
            }
            catch (Exception ex)
            {
                _toastNotification.Error(ex.Message);
            }
        }
    }
}