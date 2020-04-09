namespace FitDontQuit.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;
    using FitDontQuit.Data.Models.Enums;

    using static FitDontQuit.Common.AttributesConstraints.Membership;

    public class Membership : BaseDeletableModel<int>
    {
        public Membership()
        {
            this.Purchases = new HashSet<PurchasedMembership>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }

        public Duration Duration { get; set; }

        public bool HaveATrainer { get; set; }

        public AmountOfPeopleLimit AmountOfPeopleLimit { get; set; }

        public VisitLimit VisitLimit { get; set; }

        public virtual IEnumerable<PurchasedMembership> Purchases { get; set; }
    }
}
