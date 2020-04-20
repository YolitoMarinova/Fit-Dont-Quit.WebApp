namespace FitDontQuit.Web.ViewModels.Administration.Professions
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    public class DeleteProfessionModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
