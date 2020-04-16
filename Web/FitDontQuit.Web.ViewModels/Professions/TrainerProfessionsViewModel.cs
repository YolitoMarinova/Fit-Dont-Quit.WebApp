using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Professions
{
    public class TrainerProfessionsViewModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
