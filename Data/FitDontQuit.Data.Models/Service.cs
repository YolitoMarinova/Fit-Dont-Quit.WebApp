namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static FitDontQuit.Common.AttributesConstraints.Service;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Memberships = new HashSet<MembershipsServices>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(MinPriceValue, MaxPriceValue)]
        public decimal Price { get; set; }

        public virtual IEnumerable<MembershipsServices> Memberships { get; set; }
    }
}
