namespace FitDontQuit.Web.ViewModels.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class IsDateAfterNowAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.Parse(value.ToString()) < DateTime.Now)
            {
                return new ValidationResult("Choosen date can not be expire.");
            }

            return ValidationResult.Success;
        }
    }
}
