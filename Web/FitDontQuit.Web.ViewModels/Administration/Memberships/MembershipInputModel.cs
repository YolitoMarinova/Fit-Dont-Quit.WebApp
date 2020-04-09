namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    using static FitDontQuit.Common.AttributesConstraints.Membership;

    public class MembershipInputModel : IMapTo<MembershipServiceInputModel>, IMapFrom<MembershipServiceOutputModel>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue, ErrorMessage = "Price shoul'd be more than zero!")]
        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public bool HaveATrainer { get; set; }

        public AmountOfPeopleLimit AmountOfPeopleLimit { get; set; }

        public VisitLimit VisitLimit { get; set; }

        public IEnumerable<Duration> Durations { get; set; }

        public IEnumerable<AmountOfPeopleLimit> AmountOfPeopleLimits { get; set; }

        public IEnumerable<VisitLimit> VisitsLimits { get; set; }
    }
}
