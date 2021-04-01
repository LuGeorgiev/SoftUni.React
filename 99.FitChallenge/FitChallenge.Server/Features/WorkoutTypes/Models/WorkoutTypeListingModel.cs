using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.WorkoutTypes.Models
{
    public class WorkoutTypeListingModel : IMapFrom<WorkoutType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
