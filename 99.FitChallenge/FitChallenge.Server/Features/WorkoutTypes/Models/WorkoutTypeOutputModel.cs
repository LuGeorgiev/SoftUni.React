using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Infrastructure.Mapping;

namespace FitChallenge.Server.Features.WorkoutTypes.Models
{
    public class WorkoutTypeOutputModel: IMapFrom<WorkoutType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
