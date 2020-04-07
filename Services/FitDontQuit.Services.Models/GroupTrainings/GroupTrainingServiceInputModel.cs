namespace FitDontQuit.Services.Models.GroupTrainings
{
    using System;

    public class GroupTrainingServiceInputModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int HallId { get; set; }

        public int TrainerId { get; set; }
    }
}
