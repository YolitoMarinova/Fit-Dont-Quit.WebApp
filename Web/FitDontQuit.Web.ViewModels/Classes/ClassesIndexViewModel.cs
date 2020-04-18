using FitDontQuit.Web.ViewModels.GroupTrainings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Classes
{
    public class ClassesIndexViewModel
    {
        public IEnumerable<GroupTrainingInListViewModel> GroupTrainings { get; set; }
    }
}
