namespace FitDontQuit.Services.Models.GroupTrainings
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;

    public class GroupTrainingServiceOutputModel : IMapFrom<GroupTraining>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
