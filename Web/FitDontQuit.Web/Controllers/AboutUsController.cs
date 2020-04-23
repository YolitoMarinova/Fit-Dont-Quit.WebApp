namespace FitDontQuit.Web.Controllers
{
    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.AboutUs;

    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : BaseController
    {
        private readonly ITrainersService trainersService;
        private readonly IClassesService classesService;

        public AboutUsController(
            ITrainersService trainersService,
            IClassesService classesService)
        {
            this.trainersService = trainersService;
            this.classesService = classesService;
        }

        public IActionResult Index()
        {
            var trainersCount = this.trainersService.Count();

            var classesCount = this.classesService.Count();

            var model = new AboutUsViewModel
            {
                TrainersCount = trainersCount,
                ClassesCount = classesCount,
            };
            return this.View(model);
        }
    }
}
