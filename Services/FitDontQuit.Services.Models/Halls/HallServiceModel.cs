namespace FitDontQuit.Services.Models.Halls
{
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class HallServiceModel : IMapTo<Hall>, IMapFrom<Hall>
    {
        public string Name { get; set; }

        public int SeatsCount { get; set; }
    }
}
