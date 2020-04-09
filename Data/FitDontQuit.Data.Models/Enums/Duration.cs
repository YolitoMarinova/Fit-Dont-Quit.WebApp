namespace FitDontQuit.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Duration
    {
        [Display(Name = "Without duration")]
        NoDuration = 0,

        [Display(Name = "One week")]
        SevenDays = 7,

        [Display(Name = "One year")]
        OneYear = 365,

        [Display(Name = "One month")]
        OneMonth = 31,

        [Display(Name = "Three months")]
        ThreeMonths = 93,
    }
}
