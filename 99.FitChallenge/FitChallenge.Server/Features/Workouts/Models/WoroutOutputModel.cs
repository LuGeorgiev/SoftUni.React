using System.Collections.Generic;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class WoroutOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WorkoutTypeId { get; set; }

        public string WorkoutTypeName { get; set; }

        public string Description { get; set; }

        public IEnumerable<ExcerciseInWorkoutListingModel> ExcerciseWorkouts { get; set; } = new HashSet<ExcerciseInWorkoutListingModel>();
    }
}
