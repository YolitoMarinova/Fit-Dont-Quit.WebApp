namespace FitDontQuit.Web.ViewComponents
{
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "ThreeTrainers")]
    public class ThreeTrainersViewComponent : ViewComponent
    {
        private readonly ITrainersService trainersService;

        public ThreeTrainersViewComponent(ITrainersService trainersService)
        {
            this.trainersService = trainersService;
        }

        public IViewComponentResult Invoke()
        {
            var trainers = this.trainersService.GettAll<TopTrainerViewModel>().ToList().Take(3);

            return this.View(trainers);
        }
    }
}
