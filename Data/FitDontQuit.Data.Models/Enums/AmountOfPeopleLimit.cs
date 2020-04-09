namespace FitDontQuit.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum AmountOfPeopleLimit
    {
        [Display(Name = "For one")]
        One = 0,

        [Display(Name = "For two")]
        Two = 1,
    }
}
