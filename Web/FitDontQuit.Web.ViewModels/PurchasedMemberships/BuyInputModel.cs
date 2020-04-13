using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.PurchasedMemberships;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.PurchasedMemberships
{
    public class BuyInputModel : IMapTo<PurchasedMembershipInputServiceModel>
    {
        public string UserId { get; set; }

        public int MembershipId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
