namespace FitDontQuit.Web.ViewModels.Classes
{
    using System;

    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Classes;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Trainers;

    public class DeleteClassModel : IMapFrom<ClassServiceOutputModel>
    {
        public int Id { get; set; }

        public ClassGroupTrainingViewModel GroupTraining { get; set; }

        public Hour StartHour { get; set; }

        public Hour EndHour { get; set; }

        public ClassTrainerViewModel Trainer { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int Capacity { get; set; }
    }
}
