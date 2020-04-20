namespace FitDontQuit.Web.ViewModels.Articles
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;

    public class HomeArticleViewModel : IMapFrom<ArticleServiceOutputModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
