namespace FitDontQuit.Services.Models.PurchasedMemberships
{
    using System;

    using AutoMapper;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Mapping;

    public class PurchaseUserViewModel : IMapFrom<PurchasedMembership>, IHaveCustomMappings
    {
        public string MembershipName { get; set; }

        public decimal MembershipPrice { get; set; }

        public int MembershipDuration { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PurchasedMembership, PurchaseUserViewModel>().ForMember(x => x.MembershipDuration, opt => opt.MapFrom(x => (int)x.Membership.Duration));
        }
    }
}
