namespace FitDontQuit.Web.ViewModels.Administration.Professions
{
    using System;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    public class ProfessionViewModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
