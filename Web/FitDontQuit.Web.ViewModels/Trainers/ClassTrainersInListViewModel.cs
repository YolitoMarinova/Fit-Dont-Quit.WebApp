﻿namespace FitDontQuit.Web.ViewModels.Trainers
{
    using AutoMapper;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Trainers;

    public class ClassTrainersInListViewModel : IMapFrom<TrainerServiceOutputModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<TrainerServiceOutputModel, ClassTrainersInListViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName));
        }
    }
}
