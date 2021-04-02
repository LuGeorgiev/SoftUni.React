using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class ExcerciseInWorkoutListingModel
    {
        public int ExcerciseId { get; set; }

        public string ExcerciseName { get; set; }

        public string Repetitions { get; set; }
    }
}
