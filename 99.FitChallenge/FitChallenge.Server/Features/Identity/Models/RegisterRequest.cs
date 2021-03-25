using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Identity.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
