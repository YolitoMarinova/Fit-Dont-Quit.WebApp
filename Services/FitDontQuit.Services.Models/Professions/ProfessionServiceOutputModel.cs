namespace FitDontQuit.Services.Models.Professions
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class ProfessionServiceOutputModel : IMapFrom<Profession>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
