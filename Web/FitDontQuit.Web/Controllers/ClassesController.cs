using FitDontQuit.Services.Data;
using FitDontQuit.Web.ViewModels.Classes;
using FitDontQuit.Web.ViewModels.GroupTrainings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitDontQuit.Common;
using FitDontQuit.Web.ViewModels.Trainers;

namespace FitDontQuit.Web.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
    public class ClassesController : BaseController
    {
        private readonly IGroupTrainingsService groupTrainingsService;
        private readonly ITrainersService trainersService;

        public ClassesController(IGroupTrainingsService groupTrainingsService, ITrainersService trainersService)
        {
            this.groupTrainingsService = groupTrainingsService;
            this.trainersService = trainersService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var groupTrainings = this.groupTrainingsService.GettAll<GroupTrainingInListViewModel>();

            var viewModel = new ClassesIndexViewModel
            {
                GroupTrainings = groupTrainings,
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var groupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
            var trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

            var viewModel = new CreateClassModel
            {
                GroupTrainings = groupTrainings,
                Trainers = trainers,
            };

            return this.View(viewModel);
        }
    }
}
