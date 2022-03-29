using System.ComponentModel.DataAnnotations;

namespace HomeWorkApi.Data.Attributes
{
    public class CheckPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value.ToString().ToCharArray();

            int upperChar = 0;
            int lowerChar = 0;
            int symbolChar = 0;
            int numberChar = 0;

            foreach (char c in password)
            {
                if (c > 96 && c < 123)
                    upperChar = 1;
                if (c > 61 && c < 91)
                    lowerChar = 1;
                if (c > 47 && c < 58)
                    numberChar = 1;
                if (c > 20 && c < 48)
                    symbolChar = 1;
            }

            if (upperChar == 1 && lowerChar == 1 && symbolChar == 1 && numberChar == 1)
                return ValidationResult.Success;
            return new ValidationResult("The password must consist of one uppercase letter, one lowercase letter and one number");

        }
    }
}
