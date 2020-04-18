using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.GroupTrainings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    public class ClassGroupTrainingInListViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
