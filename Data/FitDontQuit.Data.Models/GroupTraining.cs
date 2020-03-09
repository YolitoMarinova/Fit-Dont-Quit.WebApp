namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static FitDontQuit.Common.AttributesConstraints.GroupTraining;

    public class GroupTraining : BaseDeletableModel<int>
    {
        public GroupTraining()
        {
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
