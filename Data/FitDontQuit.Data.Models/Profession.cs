namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static FitDontQuit.Common.AttributesConstraints.Profession;

    public class Profession : BaseDeletableModel<int>
    {
        public Profession()
        {
            this.Trainers = new HashSet<Trainer>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        public virtual IEnumerable<Trainer> Trainers { get; set; }
    }
}
