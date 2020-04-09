namespace FitDontQuit.Web.ViewModels.Administration.Professions
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Professions;

    public class ProfessionDeleteModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }
    }
}
