using FitDontQuit.Services.Data;
using FitDontQuit.Web.ViewModels.Trainers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitDontQuit.Common;
using FitDontQuit.Web.ViewModels.Professions;
using FitDontQuit.Services;
using FitDontQuit.Services.Models.Trainers;
using FitDontQuit.Services.Mapping;

namespace FitDontQuit.Web.Controllers
{
    public class TrainersController : BaseController
    {
        private readonly ITrainersService trainersService;
        private readonly IProfessionsService professionsService;
        private readonly ICloudinaryService cloudinaryService;

        public TrainersController(ITrainersService trainersService, IProfessionsService professionsService, ICloudinaryService cloudinaryService)
        {
            this.trainersService = trainersService;
            this.professionsService = professionsService;
            this.cloudinaryService = cloudinaryService;
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
            var trainer = this.trainersService.GetById<EditTrainerInputModel>(id);

            var professions = this.professionsService.GettAll<TrainerProfessionsViewModel>();

            trainer.Professions = professions;

            return this.View(trainer);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTrainerInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (inputModel.Image != null)
            {
                inputModel.ImageUrl = await this.cloudinaryService.UploadAsync(inputModel.Image, inputModel.Image.FileName);
            }

            var trainerServiceModel = AutoMapperConfig.MapperInstance.Map<TrainerServiceInputModel>(inputModel);

            await this.trainersService.EditAsync(id, trainerServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return this.View();
        }
    }
}
