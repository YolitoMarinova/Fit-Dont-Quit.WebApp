namespace FitDontQuit.Web.ViewModels.Administration.Professions
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    using static FitDontQuit.Common.AttributesConstraints.Profession;

    public class ProfessionInputModel : IMapTo<ProfessionServiceInputModel>, IMapFrom<ProfessionServiceOutputModel>
    {
        [Required(ErrorMessage = "Please write profession name.")]
        [StringLength(NameMaxLenght, ErrorMessage = "Name should be maximum 50 symbols.")]
        public string Name { get; set; }
    }
}
