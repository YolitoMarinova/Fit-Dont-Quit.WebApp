namespace FitDontQuit.Web.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.PurchasedMemberships;
    using FitDontQuit.Web.ViewModels.Memberships;
    using FitDontQuit.Web.ViewModels.PurchasedMemberships;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static FitDontQuit.Common.ErrorMessages.PurchasedMembership;

    [Authorize]
    public class PurchasedMembershipsController : BaseController
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly IMembershipsService membershipsService;
        private readonly IPurchasedMembershipsService purchasedMembershipsService;

        public PurchasedMembershipsController(
            UserManager<ApplicationUser> userManager,
            IMembershipsService membershipsService,
            IPurchasedMembershipsService purchasedMembershipsService)
        {
            this.userManager = userManager;
            this.membershipsService = membershipsService;
            this.purchasedMembershipsService = purchasedMembershipsService;
        }

        public async Task<IActionResult> Buy(int id)
        {
            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(id);

            if (membership == null)
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var membershipByUser = this.purchasedMembershipsService.GetByUser(user);

            if (membershipByUser != null)
            {
                return this.RedirectToAction("Renew");
            }

            var model = new BuyInputModel
            {
                Id = id,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyInputModel purchasedMembershipModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var membershipByUser = this.purchasedMembershipsService.GetByUser(user);

            if (membershipByUser != null)
            {
                return this.RedirectToAction("Renew");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(purchasedMembershipModel);
            }

            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(purchasedMembershipModel.Id);

            if (membership == null)
            {
                return this.BadRequest();
            }

            var purchase = new PurchasedMembershipInputServiceModel
            {
                MembershipId = purchasedMembershipModel.Id,
                UserId = user.Id,
                StartDate = purchasedMembershipModel.StartDate,
                EndDate = purchasedMembershipModel.StartDate.AddDays((int)membership.Duration),
            };

            await this.purchasedMembershipsService.CreateAsync(purchase);

            return this.RedirectToAction("ThankYou");
        }

        //TO DO: Renew membership if already exist
        public IActionResult Renew()
        {
            return this.View();
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
