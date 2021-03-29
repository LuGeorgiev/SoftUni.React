using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitChallenge.Server.Data.Models.Base;
using FitChallenge.Server.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Excercise: DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Url]
        public string Url { get; set; }

        [Required]
        public ExcerciseType ExcerciseType { get; set; }

        [Required]
        public ExcerciseDifficulty ExcerciseDifficulty { get; set; }

        public IEnumerable<ExcerciseWorkout> ExcerciseWorkouts { get; set; } = new HashSet<ExcerciseWorkout>();
    }
}
