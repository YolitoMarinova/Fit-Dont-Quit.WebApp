﻿namespace FitDontQuit.Web.ViewModels.Administration.Memberships
{
    using System;

    using FitDontQuit.Data.Models.Enums;
    using FitDontQuit.Services.Mapping;
    using FitDontQuit.Services.Models.Memberships;

    public class MembershipViewModel : IMapFrom<MembershipServiceOutputModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public bool HaveATrainer { get; set; }

        public AmountOfPeopleLimit AmountOfPeopleLimit { get; set; }

        public VisitLimit VisitLimit { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
