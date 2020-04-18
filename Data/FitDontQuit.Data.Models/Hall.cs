namespace FitDontQuit.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FitDontQuit.Data.Common.Models;

    using static FitDontQuit.Common.AttributesConstraints.Hall;

    public class Hall : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Range(SeatsMinCount, SeatsMaxCount)]
        public int SeatsCount { get; set; }
    }
}
