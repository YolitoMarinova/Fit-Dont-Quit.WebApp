namespace FitDontQuit.Web.ViewModels.PurchasedMemberships
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.PurchasedMemberships;

    using FitDontQuit.Web.ViewModels.Attributes;

    public class BuyInputModel : IMapTo<PurchasedMembershipInputServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [IsDateAfterNowAttribute]
        public DateTime StartDate { get; set; }
    }
}
