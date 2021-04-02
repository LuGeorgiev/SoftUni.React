using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitChallenge.Server.Data;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Features.WorkoutTypes.Models;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Features.WorkoutTypes
{
    public class WorkoutTypeService : IWorkoutTypeService
    {
        private readonly FitChallengeDbContext db;
        private readonly IMapper mapper;

        public WorkoutTypeService(FitChallengeDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<WorkoutTypeOutputModel>>> ContainsName(string name)
            => await mapper
                .ProjectTo<WorkoutTypeOutputModel>(
                    db.WorkoutTypes
                        .Where(wt => wt.Name.Contains(name) && wt.IsDeleted == false))
                .ToListAsync();
        public async Task<WorkoutTypeOutputModel> Create(WorkoutTypeCreateModel model)
        {
            var workoutType = new WorkoutType
            {
                Name = model.Name,
                Description = model.Description
            };

            await db.WorkoutTypes.AddAsync(workoutType);
            await db.SaveChangesAsync();

            return mapper.Map<WorkoutTypeOutputModel>(workoutType);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await db.WorkoutTypes.FirstOrDefaultAsync(x => x.Id == id);

            return result == null 
                ? Result.Failure("Not Found") 
                : Result.Success ;
        }

        public async Task<WorkoutTypeOutputModel> Edit(WorkoutTypeEditModel model)
        {
            var workoutType = await db.WorkoutTypes.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsDeleted == false);
            if (workoutType == null)
            {
                return null;
            }

            if (workoutType.Name != model.Name)
            {
                workoutType.Name = model.Name;
            }

            if (workoutType.Description != model.Description)
            {
                workoutType.Description = model.Description;
            }

            await db.SaveChangesAsync();

            return mapper.Map<WorkoutTypeOutputModel>(workoutType);
        }

        public async Task<Result<IEnumerable<WorkoutTypeListingModel>>> GetAll()
            => await mapper
                .ProjectTo<WorkoutTypeListingModel>(db.WorkoutTypes.Where(x => x.IsDeleted == false))
                .ToListAsync();

        public async Task<WorkoutTypeOutputModel> GetById(int id)
        {
            var wt = await db.WorkoutTypes.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (wt == null)
            {
                return null;
            }

            return mapper.Map<WorkoutTypeOutputModel>(wt);
        }
    }
}
