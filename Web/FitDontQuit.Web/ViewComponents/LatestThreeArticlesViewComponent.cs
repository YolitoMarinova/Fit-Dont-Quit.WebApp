namespace FitDontQuit.Web.ViewComponents
{
    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.Articles;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "LatestThreeArticles")]
    public class LatestThreeArticlesViewComponent : ViewComponent
    {
        private readonly IArticlesService articlesService;

        public LatestThreeArticlesViewComponent(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IViewComponentResult Invoke()
        {
            var latestArticles = this.articlesService.GettThreeLatest<LatestArticleViewModel>();

            return this.View(latestArticles);
        }
    }
}
