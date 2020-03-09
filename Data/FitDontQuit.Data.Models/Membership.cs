namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static FitDontQuit.Common.AttributesConstraints.Membership;

    public class Membership : BaseDeletableModel<int>
    {
        public Membership()
        {
            this.Services = new HashSet<MembershipsServices>();
            this.Purchaseds = new HashSet<PurchasedMembership>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }

        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }

        public virtual IEnumerable<MembershipsServices> Services { get; set; }

        public virtual IEnumerable<PurchasedMembership> Purchaseds { get; set; }
    }
}
