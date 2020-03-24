namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;

    using static FitDontQuit.Common.AttributesConstraints.Hall;

    public class HallInputModel : IMapTo<HallServiceModel>, IMapFrom<Hall>
    {
        [Required]
        [StringLength(NameMaxLenght, ErrorMessage = "Name should be maximum 100 symbols.")]
        public string Name { get; set; }

        [Range(SeatsMinCount, SeatsMaxCount, ErrorMessage = "Count of seats can be between 5 and 300.")]
        public int SeatsCount { get; set; }
    }
}
