namespace FitDontQuit.Services.Models.Professions
{
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class ProfessionServiceInputModel : IMapFrom<Profession>, IMapTo<Profession>
    {
        public string Name { get; set; }
    }
}
