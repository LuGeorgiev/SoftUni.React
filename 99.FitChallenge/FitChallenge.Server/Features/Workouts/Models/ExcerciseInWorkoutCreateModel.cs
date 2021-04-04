using System;
using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class ExcerciseInWorkoutCreateModel
    {
        [Required]
        public int ExcerciseId { get; set; }


        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        public string Repetitions { get; set; }

        [Required]
        [Range(0, 20)]
        public int ExecutionOrder { get; set; }
    }
}
