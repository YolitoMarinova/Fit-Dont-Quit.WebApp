namespace FitDontQuit.Data.Models
{
    using FitDontQuit.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static FitDontQuit.Common.AttributesConstraints.Period;

    public class Period : BaseDeletableModel<int>
    {
        public Period()
        {
            this.Memberships = new HashSet<Membership>();
        }

        [Range(MinYearsValue, MaxYearsValue)]
        public int Years { get; set; }

        [Range(MinMonthsValue, MaxMonthsValue)]
        public int Months { get; set; }

        [Range(MinDaysValue, MaxDaysValue)]
        public int Days { get; set; }

        public virtual IEnumerable<Membership> Memberships { get; set; }
    }
}
