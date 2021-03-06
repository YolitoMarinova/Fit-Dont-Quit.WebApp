﻿namespace FitDontQuit.Web.ViewComponents
{
    using System.Linq;

    using FitDontQuit.Services.Data;
    using FitDontQuit.Web.ViewModels.Memberships;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "ThreeMemberships")]
    public class ThreeMembershipsViewComponent : ViewComponent
    {
        private readonly IMembershipsService membershipsService;

        public ThreeMembershipsViewComponent(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public IViewComponentResult Invoke()
        {
            var memberships = this.membershipsService
                .GetByNames<MembershipPartilViewModel>(new string[] { "One week challenge", "Basic", "Special" })
                .ToList();

            return this.View(memberships);
        }
    }
}
