using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Articles;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Articles
{
    public class DeleteArticleModel : IMapFrom<ArticleServiceOutputModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
