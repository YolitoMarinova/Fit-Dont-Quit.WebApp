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
            var user = await this.userManager.GetUserAsync(this.User);

            var membershipByUser = this.purchasedMembershipsService.GetByUser(user);

            if (membershipByUser != null)
            {
                return this.RedirectToAction("Renew");
            }

            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(id);

            if (membership == null)
            {
                return this.NotFound();
            }

            var model = new BuyInputModel
            {
                UserId = user.Id,
                MembershipId = id,
            };

            this.ViewBag.id = id;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id, string userId, BuyInputModel purchasedMembershipModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var membershipByUser = this.purchasedMembershipsService.GetByUser(user);

            if (membershipByUser != null)
            {
                return this.RedirectToAction("Renew");
            }

            if (!this.ModelState.IsValid)
            {
                purchasedMembershipModel.MembershipId = id;
                purchasedMembershipModel.UserId = userId;

                return this.View(purchasedMembershipModel);
            }

            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(id);

            if (membership == null)
            {
                return this.BadRequest();
            }

            if (userId == null)
            {
                return this.BadRequest();
            }

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            DateTime startDate;

            if (!DateTime.TryParse(purchasedMembershipModel.StartDate, culture, DateTimeStyles.None, out startDate))
            {
                return this.BadRequest();
            }

            DateTime endDate;

            if (!DateTime.TryParse(purchasedMembershipModel.EndDate, culture, DateTimeStyles.None, out endDate))
            {
                return this.BadRequest();
            }

            if (startDate.AddDays((int)membership.Duration) != endDate)
            {
                return this.BadRequest();
            }

            var purchase = new PurchasedMembershipInputServiceModel
            {
                MembershipId = id,
                UserId = userId,
                StartDate = startDate,
                EndDate = endDate,
            };

            var serviceModel = AutoMapperConfig.MapperInstance.Map<PurchasedMembershipInputServiceModel>(purchase);

            await this.purchasedMembershipsService.CreateAsync(serviceModel);

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
