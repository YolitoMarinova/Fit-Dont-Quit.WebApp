namespace FitDontQuit.Services.Data
{
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Models.PurchasedMemberships;

    public interface IPurchasedMembershipsService
    {
        Task CreateAsync(PurchasedMembershipInputServiceModel purchasedMembershipModel);

        PurchaseUserViewModel GetByUser(ApplicationUser user);
    }
}
