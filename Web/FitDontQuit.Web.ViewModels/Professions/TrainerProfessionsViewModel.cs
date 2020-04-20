namespace FitDontQuit.Web.ViewModels.Professions
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    public class TrainerProfessionsViewModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
