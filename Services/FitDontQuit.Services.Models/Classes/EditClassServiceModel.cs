using FitDontQuit.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FitDontQuit.Common.AttributesConstraints.Class;

namespace FitDontQuit.Services.Models.Classes
{
    public class EditClassServiceModel
    {
        public Hour StartHour { get; set; }

        public Hour EndHour { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [Range(CapacityMinCount, CapacityMaxCount)]
        public int Capacity { get; set; }

        public int GroupTrainingId { get; set; }

        public int TrainerId { get; set; }
    }
}
