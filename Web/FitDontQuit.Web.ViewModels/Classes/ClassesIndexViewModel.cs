namespace FitDontQuit.Web.ViewModels.Classes
{
    using System.Collections.Generic;

    using FitDontQuit.Web.ViewModels.GroupTrainings;

    public class ClassesIndexViewModel
    {
        public IEnumerable<GroupTrainingInListViewModel> GroupTrainings { get; set; }

        public IEnumerable<ClassInListViewModel> Classes { get; set; }
    }
}
