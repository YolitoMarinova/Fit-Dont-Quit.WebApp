namespace FitDontQuit.Services.Models.Articles
{
    using FitDontQuit.Data.Models;

    public class CreateArticleServiceModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }
    }
}
