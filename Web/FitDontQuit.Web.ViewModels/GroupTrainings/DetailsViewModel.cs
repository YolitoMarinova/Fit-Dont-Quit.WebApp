namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;

    public class DetailsViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
