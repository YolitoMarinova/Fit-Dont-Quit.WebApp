namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    using static FitDontQuit.Common.AttributesConstraints.Membership;

    public class MembershipInputModel : IMapTo<MembershipServiceModel>, IMapFrom<Membership>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public IEnumerable<Duration> Durations { get; set; }
    }
}
