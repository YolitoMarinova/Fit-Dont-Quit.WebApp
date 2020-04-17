using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Administration.Professions
{
    public class DeleteProfessionModel : IMapFrom<ProfessionServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
