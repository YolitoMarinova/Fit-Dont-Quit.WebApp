namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Memberships = new HashSet<MembershipsServices>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual IEnumerable<MembershipsServices> Memberships { get; set; }
    }
}
