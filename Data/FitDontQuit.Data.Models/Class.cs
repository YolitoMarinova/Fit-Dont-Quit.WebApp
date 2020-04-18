using FitDontQuit.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FitDontQuit.Common.AttributesConstraints.Class;

namespace FitDontQuit.Data.Models
{
    public class Class
    {
        public int Id { get; set; }

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
