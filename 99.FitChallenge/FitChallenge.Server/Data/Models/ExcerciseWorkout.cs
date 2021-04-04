using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitChallenge.Server.Data.Models.Base;

namespace FitChallenge.Server.Data.Models
{
    public class ExcerciseWorkout : DeletableEntity
    {
        public int ExcerciseId { get; set; }

        [ForeignKey(nameof(ExcerciseId))]
        public Excercise Excercise { get; set; }

        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        public string Repetitions { get; set; }

        [Required]
        [Range(0, 20)]
        public int ExecutionOrder { get; set; }
    }
}
