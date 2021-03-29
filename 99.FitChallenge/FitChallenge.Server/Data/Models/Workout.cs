using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitChallenge.Server.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Workout : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int WorkoutTypeId { get; set; }

        [ForeignKey(nameof(WorkoutTypeId))]
        public WorkoutType WorkoutType { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }

        public IEnumerable<ExcerciseWorkout> ExcerciseWorkouts { get; set; } = new HashSet<ExcerciseWorkout>();

    }
}
