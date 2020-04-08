namespace FitDontQuit.Services.Models.Articles
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class ArticleServiceOutputModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public Trainer Trainer { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
