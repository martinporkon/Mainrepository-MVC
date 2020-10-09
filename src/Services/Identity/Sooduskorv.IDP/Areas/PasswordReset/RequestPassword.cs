using System.ComponentModel.DataAnnotations;

namespace Sooduskorv.IDP.Areas.PasswordReset
{
    public class RequestPassword
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}