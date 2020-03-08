namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
