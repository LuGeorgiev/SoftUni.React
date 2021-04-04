using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Features.Workouts.Models;

namespace FitChallenge.Server.Features.Workouts
{
    public interface IWorkoutService
    {
        Task<WorkoutOutputModel> GetById(int id);

        Task<Result<IEnumerable<WorkoutOutputModel>>> ContainsName(string name);

        Task<Result<IEnumerable<WorkoutListingModel>>> GetAll();

        Task<WorkoutOutputModel> Create(WorkoutCreateModel model);

        Task<WorkoutOutputModel> Edit(WorkoutEditModel model);

        Task<Result> Delete(int id);
    }
}
