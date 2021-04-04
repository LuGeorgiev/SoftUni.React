using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.Workouts.Models
{
    public class ExcerciseInWorkoutListingModel: IMapFrom<ExcerciseWorkout>
    {
        public int ExcerciseId { get; set; }

        public string ExcerciseName { get; set; }

        public string Repetitions { get; set; }

        public void Mapping(AutoMapper.Profile mappre)
            => mappre
            .CreateMap<ExcerciseWorkout, ExcerciseInWorkoutListingModel>()
            .ForMember(x => x.ExcerciseName, cfg => 
                cfg.MapFrom(x => x.Excercise.Name));
    }
}
