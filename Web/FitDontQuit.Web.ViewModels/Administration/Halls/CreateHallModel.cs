namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;

    using static FitDontQuit.Common.AttributesConstraints.Hall;

    public class CreateHallModel : IMapTo<CreateHallServiceModel>
    {
        [Required(ErrorMessage = "Please write hall name.")]
        [StringLength(NameMaxLenght, ErrorMessage = "Name should be maximum 100 symbols.")]
        public string Name { get; set; }

        [Range(SeatsMinCount, SeatsMaxCount, ErrorMessage = "Count of seats can be between 5 and 300.")]
        public int SeatsCount { get; set; }
    }
}
