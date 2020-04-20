namespace FitDontQuit.Web.ViewModels.Administration.Services
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Services;

    public class DeleteServiceModel : IMapFrom<ServiceServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
