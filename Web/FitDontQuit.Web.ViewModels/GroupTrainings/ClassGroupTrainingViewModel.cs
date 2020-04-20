namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;

    public class ClassGroupTrainingViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public string Name { get; set; }
    }
}
