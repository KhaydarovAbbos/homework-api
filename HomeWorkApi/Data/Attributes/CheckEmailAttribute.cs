using System.ComponentModel.DataAnnotations;

namespace HomeWorkApi.Data.Attributes
{
    public class CheckEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;

            if (email.Contains("@gmail.com") || email.Contains("@yandex.ru") || email.Contains("@email.com"))
                return ValidationResult.Success;

            return new ValidationResult("Please enter only gmail or yandex or email email!");
        }
    }
}
