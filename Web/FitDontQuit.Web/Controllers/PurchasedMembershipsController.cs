using FitDontQuit.Data.Models;
using FitDontQuit.Services.Data;
using FitDontQuit.Services.Mapping;
using FitDontQuit.Services.Models.PurchasedMemberships;
using FitDontQuit.Web.ViewModels.Memberships;
using FitDontQuit.Web.ViewModels.PurchasedMemberships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Controllers
{
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
            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(id);

            if (membership == null)
            {
                return this.NotFound();
            }

            var model = new BuyViewModels
            {
                User = user,
                Membership = membership,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id, string userId, BuyViewModels purchasedMembershipModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
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

            if (DateTime.TryParse(purchasedMembershipModel.StartDate, culture, DateTimeStyles.None, out startDate))
            {
                //startDate = DateTime.Parse(purchasedMembershipModel.StartDate, culture);
            }
            else
            {
                return this.BadRequest();
            }

            DateTime endDate;

            if (DateTime.TryParse(purchasedMembershipModel.EndDate, culture, DateTimeStyles.None, out endDate))
            {
                endDate = DateTime.Parse(purchasedMembershipModel.EndDate, culture);
            }
            else
            {
                return this.BadRequest();
            }

            var purchase = new BuyInputModel
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

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
