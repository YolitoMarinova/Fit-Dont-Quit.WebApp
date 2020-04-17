namespace FitDontQuit.Web.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Services;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;
    using FitDontQuit.Web.ViewModels.Professions;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            var trainerModel = new CreateTrainerModel();

            var professions = this.professionsService.GettAll<TrainerProfessionsViewModel>();

            trainerModel.Professions = professions;

            return this.View(trainerModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainerModel trainerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(trainerModel);
            }

            if (trainerModel.Image != null)
            {
                trainerModel.ImageUrl = await this.cloudinaryService.UploadAsync(trainerModel.Image, trainerModel.Image.FileName);
            }

            var serviceModel = AutoMapperConfig.MapperInstance.Map<CreateTrainerInputModel>(trainerModel);

            await this.trainersService.CreateAsync(serviceModel);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]

        public IActionResult Edit(int id)
        {
            var trainer = this.trainersService.GetById<EditTrainerModel>(id);

            var professions = this.professionsService.GettAll<TrainerProfessionsViewModel>();

            trainer.Professions = professions;

            return this.View(trainer);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTrainerModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (inputModel.Image != null)
            {
                inputModel.ImageUrl = await this.cloudinaryService.UploadAsync(inputModel.Image, inputModel.Image.FileName);
            }

            var trainerServiceModel = AutoMapperConfig.MapperInstance.Map<EditTrainerInputServiceModel>(inputModel);

            await this.trainersService.EditAsync(id, trainerServiceModel);

            return this.RedirectToAction("Index");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        public IActionResult Delete(int id)
        {
            var trainerModel = this.trainersService.GetById<DeleteTrainerModel>(id);

            if (trainerModel == null)
            {
                return this.NotFound();
            }

            return this.View(trainerModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTrainerModel trainerModel)
        {
            await this.trainersService.DeleteAsync(trainerModel.Id);

            return this.RedirectToAction("Index");
        }
    }
}
