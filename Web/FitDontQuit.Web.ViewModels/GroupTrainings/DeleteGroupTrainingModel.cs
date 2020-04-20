namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;

    public class DeleteGroupTrainingModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
