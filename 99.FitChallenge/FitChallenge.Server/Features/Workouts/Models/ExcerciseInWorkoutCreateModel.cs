using System;
using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class ExcerciseInWorkoutCreateModel
    {
        [Required]
        public int ExcerciseId { get; set; }


        [Required]
        [Range(1, 200)]
        public string Repetitions { get; set; }

        [Required]
        [Range(0, 20)]
        public int ExecutionOrder { get; set; }
    }
}
