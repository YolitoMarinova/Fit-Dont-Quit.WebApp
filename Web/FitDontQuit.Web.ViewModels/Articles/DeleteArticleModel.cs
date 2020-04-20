namespace FitDontQuit.Web.ViewModels.Articles
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Articles;

    public class DeleteArticleModel : IMapFrom<ArticleServiceOutputModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
