using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Trainers;
using FitDontQuit.Web.ViewModels.Professions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static FitDontQuit.Common.AttributesConstraints.Trainer;

namespace FitDontQuit.Web.ViewModels.Trainers
{
    public class CreateTrainerModel : IMapTo<CreateTrainerInputModel>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string LastName { get; set; }

        [Range(MinimumAge, MaximumAge)]
        public int Age { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]

        [StringLength(MaxPhoneLenght)]
        public string PhoneNumber { get; set; }

        public string InstagramUrl { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }

        public int ProfessionId { get; set; }

        public IEnumerable<TrainerProfessionsViewModel> Professions { get; set; }
    }
}
