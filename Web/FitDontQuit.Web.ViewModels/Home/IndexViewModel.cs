namespace FitDontQuit.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using FitDontQuit.Web.ViewModels.Articles;
    using FitDontQuit.Web.ViewModels.GroupTrainings;
    using FitDontQuit.Web.ViewModels.Memberships;
    using FitDontQuit.Web.ViewModels.Trainers;

    public class IndexViewModel
    {
        public IEnumerable<TopTrainerViewModel> Trainers { get; set; }

        public IEnumerable<MembershipPartilViewModel> Memberships { get; set; }

        public IEnumerable<LatestArticleViewModel> Articles { get; set; }

        public GroupTrainingInListViewModel[] Classes { get; set; }
    }
}
