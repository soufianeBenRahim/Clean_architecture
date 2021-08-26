using System.ComponentModel.DataAnnotations;

namespace Clean_Architecture_Soufiane.Services.Identity.API.Models.AccountViewModels
{
    public record ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
