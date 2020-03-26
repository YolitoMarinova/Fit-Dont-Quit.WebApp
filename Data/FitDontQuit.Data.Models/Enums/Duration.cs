namespace FitDontQuit.Data.Models.Enums
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum Duration
    {
        [Display(Name = "Without duration")]
        NoDuration = 0,

        [Display(Name = "One year")]
        OneYear = 1,

        [Display(Name = "Three months")]
        ThreeMonths = 2,

        [Display(Name = "One month")]
        OneMonth = 3,

        [Display(Name = "One week")]
        SevenDays = 4,
    }
}
