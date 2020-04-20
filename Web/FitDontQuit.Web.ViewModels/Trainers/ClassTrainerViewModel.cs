namespace FitDontQuit.Web.ViewModels.Trainers
{
    using AutoMapper;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;

    public class ClassTrainerViewModel : IMapFrom<TrainerServiceOutputModel>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                 .CreateMap<TrainerServiceOutputModel, ClassTrainerViewModel>()
                 .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}
