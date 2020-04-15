using FitDontQuit.Services.Data;
using FitDontQuit.Web.ViewModels.Trainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitDontQuit.Common;

namespace FitDontQuit.Web.Controllers
{
    public class TrainersController : BaseController
    {
        private readonly ITrainersService trainersService;

        public TrainersController(ITrainersService trainersService)
        {
            this.trainersService = trainersService;
        }

        public IActionResult Index()
        {
            var trainers = this.trainersService.GettAll<TrainerViewModel>();

            var model = new AllTrainersViewModel
            {
                Trainers = trainers,
            };

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]

        public IActionResult Edit(int id)
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
