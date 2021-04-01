using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.WorkoutTypes.Models
{
    public class WorkoutTypeEditModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
