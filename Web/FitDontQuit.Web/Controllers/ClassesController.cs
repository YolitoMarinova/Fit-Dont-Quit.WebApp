using FitDontQuit.Services.Data;
using FitDontQuit.Web.ViewModels.Classes;
using FitDontQuit.Web.ViewModels.GroupTrainings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Controllers
{
    public class ClassesController : BaseController
    {
        private readonly IGroupTrainingsService groupTrainingsService;

        public ClassesController(IGroupTrainingsService groupTrainingsService)
        {
            this.groupTrainingsService = groupTrainingsService;
        }

        public IActionResult Index()
        {
            var groupTrainings = this.groupTrainingsService.GettAll<GroupTrainingInListViewModel>();

            var viewModel = new ClassesIndexViewModel
            {
                GroupTrainings = groupTrainings,
            };

            return this.View(viewModel);
        }
    }
}
