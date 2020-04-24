namespace FitDontQuit.Web.ViewModels.GroupTrainings
{
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.GroupTrainings;
    using Ganss.XSS;

    public class DetailsViewModel : IMapFrom<GroupTrainingServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string ImageUrl { get; set; }
    }
}
