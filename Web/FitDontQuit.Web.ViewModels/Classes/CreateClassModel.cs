namespace FitDontQuit.Web.ViewModels.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Trainers;

    using static FitDontQuit.Common.AttributesConstraints.Class;

    public class CreateClassModel
    {
        [DisplayName("Start hour")]
        public Hour StartHour { get; set; }

        [DisplayName("End hour")]
        public Hour EndHour { get; set; }

        [DisplayName("Day")]
        public DayOfWeek DayOfWeek { get; set; }

        [DisplayName("Capacity")]
        [Range(CapacityMinCount, CapacityMaxCount)]
        public int Capacity { get; set; }

        [DisplayName("Class")]
        public int GroupTrainingId { get; set; }

        [DisplayName("Trainer")]
        public int TrainerId { get; set; }

        public IEnumerable<ClassTrainersInListViewModel> Trainers { get; set; }

        public IEnumerable<ClassGroupTrainingInListViewModel> GroupTrainings { get; set; }
    }
}
