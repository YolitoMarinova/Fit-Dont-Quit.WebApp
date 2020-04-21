namespace FitDontQuit.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;
    using Microsoft.AspNetCore.Http;

    using static FitDontQuit.Common.AttributesConstraints.Article;

    public class CreateArticleModel : IMapTo<CreateArticleServiceModel>
    {
        [Required]
        [StringLength(maximumLength: TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }
    }
}
