using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Features.WorkoutTypes.Models;

namespace FitChallenge.Server.Features.WorkoutTypes
{
    public interface IWorkoutTypeService
    {
        Task<WorkoutTypeOutputModel> GetById(int id);

        Task<IEnumerable<WorkoutTypeOutputModel>> ContainsName(string name);

        Task<IEnumerable<WorkoutTypeListingModel>> GetAll();

        Task<WorkoutTypeOutputModel> Create(WorkoutTypeCreateModel model);

        Task<WorkoutTypeOutputModel> Edit(WorkoutTypeEditModel model);
    }
}
