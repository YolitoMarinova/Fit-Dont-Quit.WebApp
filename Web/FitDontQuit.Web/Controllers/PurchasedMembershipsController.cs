using FitDontQuit.Data.Models;
using FitDontQuit.Services.Data;
using FitDontQuit.Web.ViewModels.Memberships;
using FitDontQuit.Web.ViewModels.PurchasedMemberships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitDontQuit.Web.Controllers
{
    [Authorize]
    public class PurchasedMembershipsController : BaseController
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly IMembershipsService membershipsService;

        public PurchasedMembershipsController(UserManager<ApplicationUser> userManager, IMembershipsService membershipsService)
        {
            this.userManager = userManager;
            this.membershipsService = membershipsService;
        }

        public async Task<IActionResult> Buy(int id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var membership = this.membershipsService.GetById<PurchasedMembershipModel>(id);

            var model = new BuyViewModels
            {
                User = user,
                Membership = membership,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyViewModels purchasedMembershipModel)
        {
            //TO DO: Make service
            //var purchase = new PurchasedMembership
            //{ 
            //MembershipId = purchasedMembershipModel.Membership.Id,
            //UserId = purchasedMembershipModel.User.Id,
            //EndDate = ,
            //StartDate = ,
            //};

            return this.View();
        }
    }
}
