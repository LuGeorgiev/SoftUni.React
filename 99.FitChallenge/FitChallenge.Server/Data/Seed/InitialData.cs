using System;
using System.Collections.Generic;
using FitChallenge.Server.Data.Models;

namespace FitChallenge.Server.Data.Seed
{
    public static class InitialData
    {
        public static IEnumerable<WorkoutType> BasicWorkoutTypes
            => new List<WorkoutType> 
            {
                new WorkoutType { Id = 1, Name = "EMOM", Description = "Every minute on the minute.", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"},
                new WorkoutType { Id = 2, Name = "AMRAP", Description = "As many rounds as possible.", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"},
                new WorkoutType { Id = 3, Name = "RFT", Description = "Rounds for time.", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"},
                new WorkoutType { Id = 4, Name = "CHIPPER", Description = "A one-round series of exercises, usually with high reps, to be completed in the fastest time possible.", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"},
                new WorkoutType { Id = 5, Name = "LADDER", Description = "One or more movements, increasing or decreasing the workload over time", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"},
                new WorkoutType { Id = 6, Name = "TABATA", Description = "Do eight rounds of high-intensity intervals, alternating 20 seconds effort with 10 seconds rest.", CreatedOn = DateTime.UtcNow, CreatedBy = "Db migration"}
            };
    }
}
