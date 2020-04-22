namespace FitDontQuit.Web.ViewModels.Trainers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;
    using FitDontQuit.Web.ViewModels.Professions;
    using Microsoft.AspNetCore.Http;

    using static FitDontQuit.Common.AttributesConstraints.Trainer;

    public class CreateTrainerModel : IMapTo<CreateTrainerInputModel>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Range(MinimumAge, MaximumAge)]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(MaxPhoneLenght)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Instagram profile")]
        public string InstagramUrl { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }

        [DisplayName("Profession")]
        public int ProfessionId { get; set; }

        public IEnumerable<TrainerProfessionsViewModel> Professions { get; set; }
    }
}
