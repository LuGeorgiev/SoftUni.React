using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Features.Workouts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitChallenge.Server.WebConstants.Controllers;

namespace FitChallenge.Server.Features.Workouts
{
    [AllowAnonymous]
    public class WorkoutController : ApiController
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<WorkoutOutputModel>> Get(int id)
        {
            var result = await workoutService.GetById(id);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpGet]
        [Route(nameof(GetByName))]
        public async Task<ActionResult<IEnumerable<WorkoutOutputModel>>> GetByName(string name)
            => await workoutService.ContainsName(name);

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<WorkoutListingModel>>> GetAll()
            => await workoutService.GetAll();

        [HttpPost]
        public async Task<ActionResult<WorkoutOutputModel>> Create(WorkoutCreateModel model)
        {
            var result = await workoutService.Create(model);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpPut]
        public async Task<ActionResult<WorkoutOutputModel>> Edit(WorkoutEditModel model)
        {
            var result = await workoutService.Edit(model);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult<Result>> Delete(int id)
        {
            var result = await workoutService.Delete(id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result;
        }
    }
}
