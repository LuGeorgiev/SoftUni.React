using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Data.Models
{    
    public class ExcerciseWorkout 
    {
        public int ExcerciseId { get; set; }

        [ForeignKey(nameof(ExcerciseId))]
        public Excercise Excercise { get; set; }

        public int WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }

        [Required]
        [Range(2,200)]
        public string Repetitions { get; set; }
    }
}
