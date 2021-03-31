using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Data.Models.Enums;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.Excercises.Models
{
    public class ExcerciseListingModel : IMapFrom<Excercise>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ExcerciseType ExcerciseType { get; set; }

        public ExcerciseDifficulty ExcerciseDifficulty { get; set; }
    }
}
