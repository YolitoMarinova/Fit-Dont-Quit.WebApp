namespace FitDontQuit.Services.Models.Articles
{
    using System;

    using FitDontQuit.Data.Models;

    public class ArticleServiceOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public Trainer Trainer { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
