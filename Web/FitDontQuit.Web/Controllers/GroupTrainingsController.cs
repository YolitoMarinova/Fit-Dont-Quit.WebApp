namespace FitDontQuit.Web.Controllers
{
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Services;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;
    using FitDontQuit.Web.ViewModels.GroupTrainings;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
    public class GroupTrainingsController : BaseController
    {
        private readonly IGroupTrainingsService groupTrainingsService;
        private readonly ICloudinaryService cloudinaryService;

        public GroupTrainingsController(IGroupTrainingsService groupTrainingsService, ICloudinaryService cloudinaryService)
        {
            this.groupTrainingsService = groupTrainingsService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupTrainingModel groupTrainingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(groupTrainingModel);
            }

            groupTrainingModel.ImageUrl = await this.cloudinaryService.UploadAsync(groupTrainingModel.Image, groupTrainingModel.Image.FileName);

            var serviceModel = AutoMapperConfig.MapperInstance.Map<CreateGroupTrainingServiceModel>(groupTrainingModel);

            await this.groupTrainingsService.CreateAsync(serviceModel);

            return this.RedirectToAction("Index", "Classes");
        }

        public IActionResult Edit(int id)
        {
            var groupTraining = this.groupTrainingsService.GetById<EditGroupTrainingModel>(id);

            if (groupTraining == null)
            {
                return this.NotFound();
            }

            return this.View(groupTraining);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGroupTrainingModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            if (inputModel.Image != null)
            {
                inputModel.ImageUrl = await this.cloudinaryService.UploadAsync(inputModel.Image, inputModel.Image.FileName);
            }

            var grouptTrainingServiceModel = AutoMapperConfig.MapperInstance.Map<EditGroupTrainingServiceModel>(inputModel);

            await this.groupTrainingsService.EditAsync(id, grouptTrainingServiceModel);

            return this.RedirectToAction("Details", new { id = id });
        }

        public IActionResult Delete(int id)
        {
            var groupTrainingModel = this.groupTrainingsService.GetById<DeleteGroupTrainingModel>(id);

            if (groupTrainingModel == null)
            {
                return this.NotFound();
            }

            return this.View(groupTrainingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteGroupTrainingModel groupTrainingModel)
        {
            await this.groupTrainingsService.DeleteAsync(groupTrainingModel.Id);

            return this.RedirectToAction("Index", "Classes");
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var groupTrainingModel = this.groupTrainingsService.GetById<DetailsViewModel>(id);

            if (groupTrainingModel == null)
            {
                return this.NotFound();
            }

            return this.View(groupTrainingModel);
        }
    }
}
