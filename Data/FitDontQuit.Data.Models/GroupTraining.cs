namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    using static FitDontQuit.Common.AttributesConstraints.GroupTraining;

    public class GroupTraining : BaseDeletableModel<int>
    {
        public GroupTraining()
        {
            this.Classes = new HashSet<Class>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Class> Classes { get; set; }
    }
}
