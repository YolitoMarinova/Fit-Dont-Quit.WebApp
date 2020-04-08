namespace FitDontQuit.Services.Models.GroupTrainings
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class GroupTrainingServiceOutputModel : IMapFrom<GroupTraining>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int HallId { get; set; }

        public int TrainerId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
