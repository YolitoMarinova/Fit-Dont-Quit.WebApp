using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Trainers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Trainers
{
    public class ClassTrainersInListViewModel : IMapFrom<TrainerServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
