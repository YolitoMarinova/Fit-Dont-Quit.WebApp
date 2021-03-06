﻿namespace FitDontQuit.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    public class PurchasedMembership : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MembershipId { get; set; }

        public virtual Membership Membership { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
