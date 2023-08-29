using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyIdentity.Models
{
    public class SignUpViewModel
    {
        [Required]
        //[Remote("","",HttpMethod = "POST",AdditionalFields ="")] //it will check your username not used before
        [Display(Name = "Username : ")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress] //to make sure you give email address in right format
        //[Remote("","",HttpMethod = "POST",AdditionalFields ="")] //it will check your email not used before
        [Display(Name = "Email Address : ")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] //to not shown characters
        [Display(Name = "Password : ")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)] //to not shown characters
        [Compare(nameof(Password))] //comapring to both password and confirm password be same
        [Display(Name = "Confirm Password : ")]
        public string ConfirmPassword { get; set; }
    }
}
