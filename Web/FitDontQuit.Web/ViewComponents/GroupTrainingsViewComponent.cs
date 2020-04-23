namespace FitDontQuit.Web.ViewComponents
{
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "GroupTrainings")]
    public class GroupTrainingsViewComponent : ViewComponent
    {
        private readonly IGroupTrainingsService groupTrainingsService;

        public GroupTrainingsViewComponent(IGroupTrainingsService groupTrainingsService)
        {
            this.groupTrainingsService = groupTrainingsService;
        }

        public IViewComponentResult Invoke()
        {
            var groupTrainings = this.groupTrainingsService.GettAll<GroupTrainingInListViewModel>().ToArray();

            return this.View(groupTrainings);
        }
    }
}
