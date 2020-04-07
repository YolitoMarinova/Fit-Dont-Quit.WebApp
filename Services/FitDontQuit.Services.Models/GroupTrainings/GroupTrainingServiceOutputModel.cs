namespace FitDontQuit.Services.Models.GroupTrainings
{
    using System;

    public class GroupTrainingServiceOutputModel
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
