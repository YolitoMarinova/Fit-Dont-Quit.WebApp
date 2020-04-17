namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    using static FitDontQuit.Common.AttributesConstraints.Trainer;

    public class Trainer : BaseDeletableModel<int>
    {
        public Trainer()
        {
            this.GroupTrainings = new HashSet<GroupTraining>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string LastName { get; set; }

        [Range(MinimumAge, MaximumAge)]
        public int Age { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        [StringLength(MaxPhoneLenght)]
        public string PhoneNumber { get; set; }

        public string InstagramUrl { get; set; }

        public string ImageUrl { get; set; }

        public int ProfessionId { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual IEnumerable<GroupTraining> GroupTrainings { get; set; }
    }
}
