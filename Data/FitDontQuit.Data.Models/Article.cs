namespace FitDontQuit.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    using static FitDontQuit.Common.AttributesConstraints.Article;

    public class Article : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TitlemaxLenght)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
