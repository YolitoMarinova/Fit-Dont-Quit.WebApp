﻿namespace FitDontQuit.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Data;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;
    using FitDontQuit.Web.ViewModels.Administration.Memberships;
    using Microsoft.AspNetCore.Mvc;

    using static FitDontQuit.Common.EnumHelper;

    public class MembershipsController : AdministrationController
    {
        private readonly IMembershipsService membershipsService;

        public MembershipsController(IMembershipsService membershipsService)
        {
            this.membershipsService = membershipsService;
        }

        public IActionResult Create()
        {
            var durations = (Duration[])Enum.GetValues(typeof(Duration));

            var viewModel = new MembershipInputModel
            {
                Durations = durations,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            var membershipServiceModel = AutoMapperConfig.MapperInstance.Map<MembershipServiceModel>(inputModel);
            await this.membershipsService.CreateAsync(membershipServiceModel);

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var name = Duration.SevenDays.GetDisplayName();

            var membership = this.membershipsService.GetById<MembershipInputModel>(id);
            var durations = (Duration[])Enum.GetValues(typeof(Duration));

            if (membership == null)
            {
                return this.NotFound();
            }

            membership.Durations = durations;


            return this.View(membership);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, MembershipInputModel membershipModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(membershipModel);
            }

            var membershipServiceModel = AutoMapperConfig.MapperInstance.Map<MembershipServiceModel>(membershipModel);
            await this.membershipsService.EditAsync(id, membershipServiceModel);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var membership = this.membershipsService.GetById<MembershipInputModel>(id);

            if (membership == null)
            {
                return this.NotFound();
            }

            await this.membershipsService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var memberships = this.membershipsService.GettAll<MembershipViewModel>();

            return this.View(memberships);
        }
    }
}