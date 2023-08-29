using System.ComponentModel.DataAnnotations;

namespace MyIdentity.Models
{
    public class SignInViewModel
    {
        [Required]
        [Display(Name = "Username : ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]
        public string PassWord { get; set; }

        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set; }
    }
}