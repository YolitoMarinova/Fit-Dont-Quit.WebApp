namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    using static FitDontQuit.Common.AttributesConstraints.Service;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.PurchasedServices = new HashSet<PurchasedServices>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }

        public IEnumerable<PurchasedServices> PurchasedServices { get; set; }
    }
}
