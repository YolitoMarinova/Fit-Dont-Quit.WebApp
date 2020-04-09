namespace FitDontQuit.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum VisitLimit
    {
        [Display(Name = "Unlimited")]
        Unlimited = 0,

        [Display(Name = "One per day")]
        OnePerDay = 1,
    }
}
