namespace FitDontQuit.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Common;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Models.Classes;
    using FitDontQuit.Web.ViewModels.Classes;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

                this.ModelState.AddModelError(string.Empty, "End hour should be after start hour!");

                return this.View(classModel);
            }

            var classes = this.classesService.GettAll<ClassInListViewModel>();

            if (classes.Any(x => x.StartHour == classModel.StartHour && x.DayOfWeek == classModel.DayOfWeek))
            {
                classModel.GroupTrainings = this.groupTrainingsService.GettAll<ClassGroupTrainingInListViewModel>();
                classModel.Trainers = this.trainersService.GettAll<ClassTrainersInListViewModel>();

                this.ModelState.AddModelError(string.Empty, "There is alredy class in this time and day.");

                return this.View(classModel);
            }

            var serviceModel = new CreateClassServiceModel
            {
                StartHour = classModel.StartHour,
                EndHour = classModel.EndHour,
                DayOfWeek = classModel.DayOfWeek,
                Capacity = classModel.Capacity,
                GroupTrainingId = classModel.GroupTrainingId,
                TrainerId = classModel.TrainerId,
            };

            await this.classesService.CreateAsync(serviceModel);

            return this.RedirectToAction("Index");
        }
    }
}
