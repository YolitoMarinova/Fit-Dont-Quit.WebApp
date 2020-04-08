﻿namespace FitDontQuit.Services.Models.Halls
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class HallServiceOutputModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
