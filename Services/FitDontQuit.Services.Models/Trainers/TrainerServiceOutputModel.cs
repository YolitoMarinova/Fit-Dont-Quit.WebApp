namespace FitDontQuit.Services.Models.Trainers
{
    using System;

    using AutoMapper;
    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class TrainerServiceOutputModel : IMapFrom<Trainer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public int ProfessionId { get; set; }

        public string ProfessionName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Trainer, TrainerServiceOutputModel>().ForMember(x => x.ProfessionName, opt => opt.MapFrom(x => x.Profession.Name));
        }
    }
}
