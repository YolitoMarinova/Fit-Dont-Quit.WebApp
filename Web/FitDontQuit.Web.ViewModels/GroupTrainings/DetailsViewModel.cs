using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.GroupTrainings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    public class DetailsViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
