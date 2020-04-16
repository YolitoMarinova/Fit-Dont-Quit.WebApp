namespace FitDontQuit.Services.Models.PurchasedMemberships
{
    using System;

    public class PurchasedMembershipInputServiceModel
    {
        public string UserId { get; set; }

        public int MembershipId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
