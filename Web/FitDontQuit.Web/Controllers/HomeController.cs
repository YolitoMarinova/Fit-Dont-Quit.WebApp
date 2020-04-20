namespace FitDontQuit.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels;
    using FitDontQuit.Web.ViewModels.Articles;
    using FitDontQuit.Web.ViewModels.Classes;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Home;
    using FitDontQuit.Web.ViewModels.Memberships;
    using FitDontQuit.Web.ViewModels.Trainers;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ITrainersService trainersService;
        private readonly IMembershipsService membershipsService;
        private readonly IArticlesService articlesService;
        private readonly IGroupTrainingsService groupTrainingService;

        public HomeController(
            ITrainersService trainersService,
            IMembershipsService membershipsService,
            IArticlesService articlesService,
            IGroupTrainingsService groupTrainingService)
        {
            this.trainersService = trainersService;
            this.membershipsService = membershipsService;
            this.articlesService = articlesService;
            this.groupTrainingService = groupTrainingService;
        }

        public IActionResult Index()
        {
            var trainers = this.trainersService.GettAll<TopTrainerViewModel>().ToList().Take(3);

            var memberships = this.membershipsService.GetByName<MembershipPartilViewModel>(new string[] { "One week challenge", "Basic", "Special" }, 3).ToList();

            var latestArticles = this.articlesService.GettThreeLatest<HomeArticleViewModel>();

            var classes = this.groupTrainingService.GettAll<GroupTrainingInListViewModel>().ToArray();

            var viewModel = new IndexViewModel
            {
                Trainers = trainers,
                Memberships = memberships,
                Articles = latestArticles,
                Classes = classes,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
