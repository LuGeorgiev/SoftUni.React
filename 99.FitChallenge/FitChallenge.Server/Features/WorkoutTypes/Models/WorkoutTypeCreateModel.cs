using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.WorkoutTypes.Models
{
    public class WorkoutTypeCreateModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
