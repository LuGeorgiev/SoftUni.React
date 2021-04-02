using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class WorkoutEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int WorkoutTypeId { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }
        
        public IEnumerable<ExcerciseInWorkoutCreateModel> ExcerciseWorkouts { get; set; } = new HashSet<ExcerciseInWorkoutCreateModel>();
    }
}
