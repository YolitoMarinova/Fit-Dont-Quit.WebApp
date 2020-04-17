using FitDontQuit.Data.Models;

namespace FitDontQuit.Services.Models.Articles
{
    public class CreateArticleServiceModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }
    }
}
