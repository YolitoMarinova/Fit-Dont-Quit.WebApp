namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using System;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;

    public class MembershipViewModel : IMapFrom<Membership>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
