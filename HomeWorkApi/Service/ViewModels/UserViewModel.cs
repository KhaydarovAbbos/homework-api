using HomeWorkApi.Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Homework.Api.Service.ViewModels
{
    public class UserViewModel
    {
        [CheckEmail]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(255,
            ErrorMessage = "Must be between 8 and 255 characters",
            MinimumLength = 8)]
        [DataType(DataType.Password)]
        [CheckPassword]
        public string Password { get; set; }
    }
}
