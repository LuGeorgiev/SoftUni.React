using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Identity.Models
{
    public class ChangePasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string OldPassword { get; set; }
    }
}
