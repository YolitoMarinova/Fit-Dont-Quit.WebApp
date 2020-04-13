namespace FitDontQuit.Web.ViewModels.PurchasedMemberships
{
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Web.ViewModels.Memberships;

    public class BuyViewModels
    {
        public ApplicationUser User { get; set; }

        public PurchasedMembershipModel Membership { get; set; }

        [Required(ErrorMessage ="Is required to input start date!")]
        [RegularExpression("^(([1-9])|((1)[0-2]))(-)([1-2][0-9]|([1-9])|(3)[0-1])(-)([1-9][0-9][0-9]{2})$", ErrorMessage ="Invalid date!")]
        public string StartDate { get; set; }

        [Required]
        [RegularExpression("^(([1-9])|((1)[0-2]))(-)([1-2][0-9]|([1-9])|(3)[0-1])(-)([1-9][0-9][0-9]{2})$", ErrorMessage = "Invalid date!")]
        public string EndDate { get; set; }
    }
}
