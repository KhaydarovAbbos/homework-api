using System;
using System.ComponentModel.DataAnnotations;
using Homework.Api.Models.Entities;
using HomeWorkApi.Data.Attributes;

namespace Homework.Api.Models
{
    public class UserModel : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [CheckPassword]
        public string Password { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [CheckEmail]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
