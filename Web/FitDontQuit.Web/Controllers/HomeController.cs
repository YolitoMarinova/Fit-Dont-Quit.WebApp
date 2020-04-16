namespace FitDontQuit.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ITrainersService trainersService;

        public HomeController(ITrainersService trainersService)
        {
            this.trainersService = trainersService;
        }

        public IActionResult Index()
        {
            var trainers = this.trainersService.GettAll<TrainerViewModel>().ToList().Take(3);

            var model = new AllTrainersViewModel
            {
                Trainers = trainers,
            };

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult AboutUs()
        {
            var trainers = this.trainersService.GettAll<TrainerViewModel>().ToList().Take(3);

            var model = new AllTrainersViewModel
            {
                Trainers = trainers,
            };

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
