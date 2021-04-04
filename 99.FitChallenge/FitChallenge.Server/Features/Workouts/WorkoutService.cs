using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitChallenge.Server.Data;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Features.Workouts.Models;
using Microsoft.EntityFrameworkCore;

namespace FitChallenge.Server.Features.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly FitChallengeDbContext db;
        private readonly IMapper mapper;

        public WorkoutService(FitChallengeDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<Result<IEnumerable<WorkoutOutputModel>>> ContainsName(string name)
            => await mapper
            .ProjectTo<WorkoutOutputModel>(
                db.Workouts
                .Include(x => x.ExcerciseWorkouts.Where(ex => ex.IsDeleted == false))
                .Where(x => x.IsDeleted == false && x.Name.Contains(name)))
            .ToListAsync();

        public async Task<WorkoutOutputModel> Create(WorkoutCreateModel model)
        {
            var workout = new Workout
            {
                Name = model.Name,
                Description = model.Description,
                WorkoutTypeId = model.WorkoutTypeId,
            };

            var excerciseWorkouts = new HashSet<ExcerciseWorkout>();
            foreach (var exWo in model.ExcerciseWorkouts)
            {
                excerciseWorkouts.Add(new ExcerciseWorkout
                {
                    ExcerciseId = exWo.ExcerciseId,
                    Repetitions = exWo.Repetitions,
                    ExecutionOrder = exWo.ExecutionOrder
                });
            };

            workout.ExcerciseWorkouts = excerciseWorkouts;
            var result = await db.Workouts.AddAsync(workout);
            await db.SaveChangesAsync();

            return mapper.Map<WorkoutOutputModel>(result.Entity);
        }

        public async Task<Result> Delete(int id)
        {
            var workout = await db.Workouts
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (workout == null)
            {
                return Result.Failure("Not Found");
            }

            var excerciseWorkout = await db.ExcerciseWorkouts
                .Where(ew => ew.WorkoutId == id)
                .ToListAsync();

            db.ExcerciseWorkouts.RemoveRange(excerciseWorkout);
            db.Workouts.Remove(workout);

            var result = await db.SaveChangesAsync();

            return result == 0
                ? Result.Failure("Not deleted")
                : Result.Success;
        }

        public async Task<WorkoutOutputModel> Edit(WorkoutEditModel model)
        {
            var workout = await db.Workouts
                .FirstOrDefaultAsync(w => w.Id == model.Id && w.IsDeleted == false);

            if (workout == null)
            {
                return null;
            }

            if (model.Description != workout.Description)
            {
                workout.Description = model.Description;
            }
            if (model.Name != workout.Name)
            {
                workout.Name = model.Name;
            }
            if (model.WorkoutTypeId != workout.WorkoutTypeId)
            {
                workout.WorkoutTypeId = model.WorkoutTypeId;
            }

            var excerciseWorkouts = await db.ExcerciseWorkouts
                .Where(ew => ew.WorkoutId == workout.Id && ew.IsDeleted == false)
                .ToListAsync();

            foreach (var exWo in model.ExcerciseWorkouts)
            {
                var currentExcerciseWorkout = excerciseWorkouts
                    .FirstOrDefault(x => x.ExcerciseId == exWo.ExcerciseId);
                if (currentExcerciseWorkout == null)
                {
                    workout.ExcerciseWorkouts.Add(
                        new ExcerciseWorkout
                        {
                            ExcerciseId = exWo.ExcerciseId,
                            ExecutionOrder = exWo.ExecutionOrder,
                            Repetitions = exWo.Repetitions
                        });
                }
                else
                {
                    if (exWo.Repetitions != currentExcerciseWorkout.Repetitions)
                    {
                        currentExcerciseWorkout.Repetitions = exWo.Repetitions;
                    }
                    if (exWo.ExecutionOrder != currentExcerciseWorkout.ExecutionOrder)
                    {
                        currentExcerciseWorkout.ExecutionOrder = exWo.ExecutionOrder;
                    }
                }
            }

            var exWoToRemove = excerciseWorkouts
                .Where(x1 => !model.ExcerciseWorkouts.Any(x2 => x2.ExcerciseId == x1.ExcerciseId))
                .ToList();
            db.ExcerciseWorkouts.RemoveRange(exWoToRemove);
            var result = await db.SaveChangesAsync();
            if (result == 0)
            {
                return null;
            }

            return mapper.Map<WorkoutOutputModel>(workout);
        }

        public async Task<Result<IEnumerable<WorkoutListingModel>>> GetAll()
            => await mapper
            .ProjectTo<WorkoutListingModel>(
                db.Workouts
                    .Include(w => w.ExcerciseWorkouts
                        .Where(we => we.IsDeleted == false)
                        .OrderBy(we => we.ExecutionOrder))
                    .Where(w => w.IsDeleted == false))
            .ToListAsync();

        public async Task<WorkoutOutputModel> GetById(int id)
        {
            var result = await db.Workouts
                .Include(w => w.ExcerciseWorkouts
                    .Where(we => we.IsDeleted == false))
                .FirstOrDefaultAsync(w => w.Id == id && w.IsDeleted == false);

            if (result == null)
            {
                return null;
            }

            return mapper.Map<WorkoutOutputModel>(result);
        }
    }
}
