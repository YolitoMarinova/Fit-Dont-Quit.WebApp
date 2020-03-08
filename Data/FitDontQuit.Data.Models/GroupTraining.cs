namespace FitDontQuit.Data.Models
{
    using System;
    using System.Collections.Generic;

    using FitDontQuit.Data.Common.Models;

    public class GroupTraining : BaseDeletableModel<int>
    {
        public GroupTraining()
        {
            this.Users = new HashSet<UsersGroupTrainings>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int HallIde { get; set; }

        public virtual Hall Hall { get; set; }

        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual IEnumerable<UsersGroupTrainings> Users { get; set; }
    }
}
