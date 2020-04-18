using FitDontQuit.Data.Models.Enums;
using FitDontQuit.Web.ViewModels.GroupTrainings;
using FitDontQuit.Web.ViewModels.Trainers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FitDontQuit.Common.AttributesConstraints.Class;

namespace FitDontQuit.Web.ViewModels.Classes
{
    public class CreateClassModel
    {
        public Hour StartHour { get; set; }

        public Hour EndHour { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [Range(CapacityMinCount, CapacityMaxCount)]
        public int Capacity { get; set; }

        public int? GroupTrainingId { get; set; }

        public int? TrainerId { get; set; }

        public IEnumerable<ClassTrainersInListViewModel> Trainers { get; set; }

        public IEnumerable<ClassGroupTrainingInListViewModel> GroupTrainings { get; set; }
    }
}
