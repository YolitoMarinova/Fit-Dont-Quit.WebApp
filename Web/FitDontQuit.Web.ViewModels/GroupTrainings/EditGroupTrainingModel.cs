namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;
    using Microsoft.AspNetCore.Http;

    using static FitDontQuit.Common.AttributesConstraints.GroupTraining;

    public class EditGroupTrainingModel : IMapFrom<GroupTrainingServiceOutputModel>, IMapTo<EditGroupTrainingServiceModel>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }
    }
}
