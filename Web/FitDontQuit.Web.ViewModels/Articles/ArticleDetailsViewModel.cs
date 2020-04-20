namespace FitDontQuit.Web.ViewModels.Articles
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;

    public class ArticleDetailsViewModel : IMapFrom<ArticleServiceOutputModel>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
