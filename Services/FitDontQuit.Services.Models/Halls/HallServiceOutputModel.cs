namespace FitDontQuit.Services.Models.Halls
{
    using System;

    public class HallServiceOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
