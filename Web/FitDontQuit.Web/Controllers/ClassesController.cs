namespace FitDontQuit.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Classes;
    using FitDontQuit.Web.ViewModels.Classes;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FitDontQuit.Common.ErrorMessages.Class;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
    public class ClassesController : BaseController
    {
        private readonly IGroupTrainingsService groupTrainingsService;
        private readonly ITrainersService trainersService;
        private readonly IClassesService classesService;

        public ClassesController(IGroupTrainingsService groupTrainingsService, ITrainersService trainersService, IClassesService classesService)
        {
            this.groupTrainingsService = groupTrainingsService;
            this.trainersService = trainersService;
            this.classesService = classesService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var groupTrainings = this.groupTrainingsService.GettAll<GroupTrainingInListViewModel>();

            var classes = this.classesService.GettAll<ClassInListViewModel>();

            var viewModel = new ClassesIndexViewModel
            {
                GroupTrainings = groupTrainings,
                Classes = classes,
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassModel classModel)
        {
            if (!this.ModelState.IsValid)
            {
                classModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                classModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                return this.View(classModel);
            }

            if (classModel.EndHour <= classModel.StartHour)
            {
                classModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                classModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                this.ModelState.AddModelError(string.Empty, InvalidHours);

                return this.View(classModel);
            }

            var classes = this.classesService.GettAll<ClassInListViewModel>();

            if (classes.Any(x => x.StartHour == classModel.StartHour && x.DayOfWeek == classModel.DayOfWeek))
            {
                classModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                classModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                this.ModelState.AddModelError(string.Empty, DayAndTimeIsTakenError);

                return this.View(classModel);
            }

            var serviceModel = AutoMapperConfig.MapperInstance.Map<CreateClassServiceModel>(classModel);

            await this.classesService.CreateAsync(serviceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.classesService.GetById<EditClassModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            var groupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
            var trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

            viewModel.GroupTrainings = groupTrainings;
            viewModel.Trainers = trainers;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClassModel editClassModel)
        {
            var model = this.classesService.GetById<EditClassModel>(id);

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                editClassModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                editClassModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                return this.View(editClassModel);
            }

            if (editClassModel.EndHour <= editClassModel.StartHour)
            {
                editClassModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                editClassModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                this.ModelState.AddModelError(string.Empty, InvalidHours);

                return this.View(editClassModel);
            }

            var classes = this.classesService.GettAll<ClassInListViewModel>();

            if (classes.Any(x => x.StartHour == editClassModel.StartHour && x.DayOfWeek == editClassModel.DayOfWeek))
            {
                editClassModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                editClassModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                this.ModelState.AddModelError(string.Empty, DayAndTimeIsTakenError);

                return this.View(editClassModel);
            }

            var editServiceModel = AutoMapperConfig.MapperInstance.Map<EditClassServiceModel>(editClassModel);

            await this.classesService.EditAsync(id, editServiceModel);

            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var viewModel = this.classesService.GetById<DeleteClassModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteClassModel deleteClassModel)
        {
            if (deleteClassModel == null)
            {
                return this.BadRequest();
            }

            await this.classesService.DeleteAsync(deleteClassModel.Id);

            return this.RedirectToAction("Index");
        }
    }
}
