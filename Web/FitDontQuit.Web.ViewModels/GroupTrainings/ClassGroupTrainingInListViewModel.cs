namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;

    public class ClassGroupTrainingInListViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
