namespace FitDontQuit.Web.ViewModels.AboutUs
{
    using System.Collections.Generic;

    using FitDontQuit.Web.ViewModels.Trainers;

    public class AboutUsViewModel
    {
        public IEnumerable<TopTrainerViewModel> Trainers { get; set; }

        public int ClassesCount { get; set; }

        public int TrainersCount { get; set; }
    }
}
