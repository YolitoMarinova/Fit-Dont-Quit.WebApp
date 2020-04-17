namespace FitDontQuit.Web.ViewModels.Trainers
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;

    public class DeleteTrainerModel : IMapFrom<TrainerServiceOutputModel>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string InstagramUrl { get; set; }

        public string ImageUrl { get; set; }

        public string ProfessionName { get; set; }
    }
}
