namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class Profession : BaseDeletableModel<int>
    {
        public Profession()
        {
            this.Trainers = new HashSet<Trainer>();
        }

        public string Name { get; set; }

        public virtual IEnumerable<Trainer> Trainers { get; set; }
    }
}
