using FitDontQuit.Data.Models;
using FitDontQuit.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Services.Models.PurchasedMemberships
{
    public class PurchasedMembershipInputServiceModel : IMapTo<PurchasedMembership>
    {
        public string UserId { get; set; }

        public int MembershipId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
