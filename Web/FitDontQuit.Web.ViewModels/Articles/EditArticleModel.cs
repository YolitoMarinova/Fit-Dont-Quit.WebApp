namespace FitDontQuit.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;
    using Microsoft.AspNetCore.Http;

    using static FitDontQuit.Common.AttributesConstraints.Article;

    public class EditArticleModel : IMapFrom<ArticleServiceOutputModel>, IMapTo<EditArticleServiceModel>
    {
        [Required]
        [StringLength(maximumLength: TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }
    }
}
