using System.ComponentModel.DataAnnotations;

namespace Sooduskorv.IDP.Areas.PasswordReset
{
    public class ResetPassword
    {
        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Your new password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your new password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string SecurityCode { get; set; }
    }
}