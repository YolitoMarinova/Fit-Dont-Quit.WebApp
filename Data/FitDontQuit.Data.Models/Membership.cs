namespace FitDontQuit.Data.Models
{
    using System;
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class Membership : BaseDeletableModel<int>
    {
        public Membership()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Services = new HashSet<MembershipsServices>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        // In months
        public int Period { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual IEnumerable<ApplicationUser> Users { get; set; }

        public virtual IEnumerable<MembershipsServices> Services { get; set; }
    }
}
