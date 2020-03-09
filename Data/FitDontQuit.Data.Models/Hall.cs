namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static FitDontQuit.Common.AttributesConstraints.Hall;

    public class Hall : BaseDeletableModel<int>
    {
        public Hall()
        {
            this.GroupTrainings = new HashSet<GroupTraining>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(SeatsMinCount, SeatsMaxCount)]
        public int SeatsCount { get; set; }

        public bool IsFree { get; set; }

        public virtual IEnumerable<GroupTraining> GroupTrainings { get; set; }
    }
}
