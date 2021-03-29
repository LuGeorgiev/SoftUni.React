using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitChallenge.Server.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class WorkoutType : Entity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public IEnumerable<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
