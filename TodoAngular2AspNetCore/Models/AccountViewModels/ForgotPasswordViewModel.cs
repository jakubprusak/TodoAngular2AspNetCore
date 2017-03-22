using System.ComponentModel.DataAnnotations;

namespace TodoAngular2AspNetCore.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
