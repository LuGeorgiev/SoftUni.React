using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Data.Models.Enums;
using FitChallenge.Server.Features.Excercises.Models;

namespace FitChallenge.Server.Features.Excercises
{
    public interface IExcerciseService
    {
        Task<Result<ExcerciseOutputModel>> FindById(int id);

        Task<Result<IEnumerable<ExcerciseListingModel>>> GetAll();

        Task<Result<IEnumerable<ExcerciseListingModel>>> GetByType(ExcerciseType type);

        Task<Result<ExcerciseOutputModel>> Create(ExcerciseCreateModel model);

        Task<Result<ExcerciseOutputModel>> Edit(ExcerciseEditModel model);

        Task<Result> Delete(int id);
    }
}
