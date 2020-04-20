namespace FitDontQuit.Services.Models.Classes
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;
    using FitDontQuit.Services.Models.Trainers;

    public class ClassServiceOutputModel : IMapFrom<Class>
    {
        public int Id { get; set; }

        public Hour StartHour { get; set; }

        public Hour EndHour { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int Capacity { get; set; }

        public int GroupTrainingId { get; set; }

        public GroupTrainingServiceOutputModel GroupTraining { get; set; }

        public int TrainerId { get; set; }

        public virtual TrainerServiceOutputModel Trainer { get; set; }
    }
}
