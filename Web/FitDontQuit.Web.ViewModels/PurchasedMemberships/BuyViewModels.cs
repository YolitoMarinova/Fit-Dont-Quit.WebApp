using FitDontQuit.Data.Models;
using FitDontQuit.Web.ViewModels.Memberships;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDontQuit.Web.ViewModels.PurchasedMemberships
{
    public class BuyViewModels
    {
        public ApplicationUser User { get; set; }

        public PurchasedMembershipModel Membership { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
