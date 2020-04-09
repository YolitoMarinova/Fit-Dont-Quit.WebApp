namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Halls;

    public class HallDeleteModel : IMapFrom<HallServiceOutputModel>
    {
        public int Id { get; set; }
    }
}
