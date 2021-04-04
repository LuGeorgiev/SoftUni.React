using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitChallenge.Server.Data;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Data.Models.Enums;
using FitChallenge.Server.Features.Excercises.Models;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Features.Excercises
{
    public class ExcerciseService : IExcerciseService
    {
        private readonly FitChallengeDbContext db;
        private readonly IMapper mapper;

        public ExcerciseService(FitChallengeDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<Result<ExcerciseOutputModel>> Create(ExcerciseCreateModel model)
        {
            var excercise = new Excercise
            {
                ExcerciseDifficulty = model.ExcerciseDifficulty,
                ExcerciseType = model.ExcerciseType,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Url = model.Url
            };

            var result = await db.AddAsync(excercise);
            await db.SaveChangesAsync();

            return  mapper.Map<ExcerciseOutputModel>(result.Entity);
        }

        public async Task<Result> Delete(int id)
        {
            var excercise = await db.Excercises
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (excercise == null)
            {
                return Result.Failure("Not found.");
            }

            db.Excercises.Remove(excercise);
            var result = await db.SaveChangesAsync();

            return result == 0
                ? Result.Failure("Not deleted succcessful.")
                : Result.Success;
        }

        public async Task<Result<ExcerciseOutputModel>> Edit(ExcerciseEditModel model)
        {
            var excercise = await db.Excercises
                .FirstOrDefaultAsync(x => x.Id == model.Id && x.IsDeleted == false);

            if (excercise == null)
            {
                return null;
            }

            if (excercise.ExcerciseType != model.ExcerciseType)
            {
                excercise.ExcerciseType = model.ExcerciseType;
            }

            if (excercise.ExcerciseDifficulty != model.ExcerciseDifficulty)
            {
                excercise.ExcerciseDifficulty = model.ExcerciseDifficulty;
            }

            if (excercise.Name != model.Name)
            {
                excercise.Name = model.Name;
            }

            if (excercise.ShortDescription != model.ShortDescription)
            {
                excercise.ShortDescription = model.ShortDescription;
            }

            if (excercise.Url != model.Url)
            {
                excercise.Url = model.Url;
            }

            await db.SaveChangesAsync();

            return mapper.Map<ExcerciseOutputModel>(excercise);
        }

        public async Task<Result<ExcerciseOutputModel>> FindById(int id)
        {
            var result = await db.Excercises
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (result == null)
            {
                return null;
            }

            return mapper.Map<ExcerciseOutputModel>(result);
        }

        public async Task<Result<IEnumerable<ExcerciseOutputModel>>> ContainsName(string name)
            => await this.mapper
                .ProjectTo<ExcerciseOutputModel>( 
                    db.Excercises
                    .Where(x => x.Name.Contains(name) && x.IsDeleted == false))
                .ToListAsync();            

        public async Task<Result<IEnumerable<ExcerciseListingModel>>> GetAll()
            => await mapper.ProjectTo<ExcerciseListingModel>(this.AllByType())
            .ToListAsync();

        public async Task<Result<IEnumerable<ExcerciseListingModel>>> GetByType(ExcerciseType type)
        => await mapper.ProjectTo<ExcerciseListingModel>(this.AllByType(type))
            .ToListAsync();

        private IQueryable<Excercise> AllByType(ExcerciseType type = ExcerciseType.None)
        {
            var query = db.Excercises.Where(x => x.IsDeleted == false);

            if (type != ExcerciseType.None)
            {
                query = query.Where(x => x.ExcerciseType == type);
            }

            return query;
        }
    }
}
