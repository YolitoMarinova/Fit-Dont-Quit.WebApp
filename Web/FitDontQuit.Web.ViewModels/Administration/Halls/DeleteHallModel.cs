using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.Halls;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    public class DeleteHallModel : IMapFrom<HallServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
