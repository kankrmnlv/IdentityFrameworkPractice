using System.ComponentModel.DataAnnotations;

namespace IdentityFrameworkPractice.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
