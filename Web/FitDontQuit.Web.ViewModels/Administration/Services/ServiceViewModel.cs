namespace FitDontQuit.Web.ViewModels.Administration.Services
{
    using System;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Services;

    public class ServiceViewModel : IMapFrom<ServiceServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
