namespace FitDontQuit.Web.ViewModels.PurchasedMemberships
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.PurchasedMemberships;

    public class BuyInputModel : IMapTo<PurchasedMembershipInputServiceModel>
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
    }
}
