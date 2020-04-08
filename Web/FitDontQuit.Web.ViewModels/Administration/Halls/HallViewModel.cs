namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    using System;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;

    public class HallViewModel : IMapFrom<HallServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
