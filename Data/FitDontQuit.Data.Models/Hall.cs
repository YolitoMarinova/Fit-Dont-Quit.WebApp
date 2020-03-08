namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class Hall : BaseDeletableModel<int>
    {
        public Hall()
        {
            this.GroupTrainings = new HashSet<GroupTraining>();
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public int SeatsCount { get; set; }

        public bool IsFree { get; set; }

        public virtual IEnumerable<GroupTraining> GroupTrainings { get; set; }
    }
}
