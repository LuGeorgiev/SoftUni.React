﻿using System.Collections.Generic;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class WorkoutListingModel : IMapFrom<Workout>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WorkoutTypeName { get; set; }

        public string Description { get; set; }

        public IEnumerable<ExcerciseInWorkoutListingModel> ExcerciseWorkouts { get; set; } = new HashSet<ExcerciseInWorkoutListingModel>();

        public void Mapping(AutoMapper.Profile mapper)
            => mapper
            .CreateMap<Workout, WorkoutListingModel>()
            .ForMember(x => x.WorkoutTypeName, cfg => 
                cfg.MapFrom(x => x.WorkoutType.Name));
    }
}
