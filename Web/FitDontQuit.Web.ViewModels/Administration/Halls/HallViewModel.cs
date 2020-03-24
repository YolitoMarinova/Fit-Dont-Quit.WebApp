using FitDontQuit.Data.Models;
using FitDontQuit.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.Administration.Halls
{
    public class HallViewModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
