using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Administration.Services
{
    public class DeleteServiceModel : IMapFrom<ServiceServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
