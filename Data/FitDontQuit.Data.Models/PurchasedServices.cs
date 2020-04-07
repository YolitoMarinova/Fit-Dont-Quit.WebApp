namespace FitDontQuit.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    public class PurchasedServices : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
