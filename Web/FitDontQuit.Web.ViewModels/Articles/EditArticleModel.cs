using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Articles;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FitDontQuit.Common.AttributesConstraints.Article;

namespace FitDontQuit.Web.ViewModels.Articles
{
    public class EditArticleModel : IMapFrom<ArticleServiceOutputModel>, IMapTo<EditArticleServiceModel>
    {
        [Required]
        [MaxLength(TitlemaxLenght)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string ImageUrl { get; set; }
    }
}
