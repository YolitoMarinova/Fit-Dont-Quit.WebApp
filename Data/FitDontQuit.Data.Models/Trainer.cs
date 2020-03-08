namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class Trainer : BaseDeletableModel<int>
    {
        public Trainer()
        {
            this.GroupTrainings = new HashSet<GroupTraining>();
            this.Articles = new HashSet<Article>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string InstagramUrl { get; set; }

        public string ImageUrl { get; set; }

        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual IEnumerable<GroupTraining> GroupTrainings { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
    }
}
