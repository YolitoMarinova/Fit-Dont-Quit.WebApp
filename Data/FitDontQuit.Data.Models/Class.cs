namespace FitDontQuit.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;
    using FitDontQuit.Data.Models.Enums;

    using static FitDontQuit.Common.AttributesConstraints.Class;

    public class Class : BaseDeletableModel<int>
    {
        public Hour StartHour { get; set; }

        public Hour EndHour { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [Range(CapacityMinCount, CapacityMaxCount)]
        public int Capacity { get; set; }

        public int GroupTrainingId { get; set; }

        public GroupTraining GroupTraining { get; set; }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
