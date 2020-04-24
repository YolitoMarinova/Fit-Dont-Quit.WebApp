namespace FitDontQuit.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;
    using Ganss.XSS;

    public class ArticleDetailsViewModel : IMapFrom<ArticleServiceOutputModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
