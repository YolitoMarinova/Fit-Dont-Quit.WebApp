namespace FitDontQuit.Web.ViewModels.Administration.Services
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class ServiceViewModel : IMapFrom<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
