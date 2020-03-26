namespace FitDontQuit.Web.ViewModels.Administration.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Services;

    using static FitDontQuit.Common.AttributesConstraints.Service;

    public class ServiceInputModel : IMapTo<ServiceServiceModel>, IMapFrom<Service>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }
    }
}
