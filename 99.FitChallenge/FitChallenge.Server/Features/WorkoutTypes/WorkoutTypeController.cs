using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Features.WorkoutTypes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FitChallenge.Server.WebConstants.Controllers;

namespace FitChallenge.Server.Features.WorkoutTypes
{
    [AllowAnonymous]
    public class WorkoutTypeController: ApiController
    {
        private readonly IWorkoutTypeService workoutTypeService;

        public WorkoutTypeController(IWorkoutTypeService workoutTypeService)
        {
            this.workoutTypeService = workoutTypeService;
        }

        [HttpGet]
        [Route(nameof(GetByName))]
        public async Task<ActionResult<IEnumerable<WorkoutTypeOutputModel>>> GetByName(string name)
            => await workoutTypeService.ContainsName(name);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<WorkoutTypeOutputModel>> GetById(int id)
        { 
            var result = await workoutTypeService.GetById(id);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }


        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<ActionResult<Result<IEnumerable<WorkoutTypeListingModel>>>> GetAll()
            => await workoutTypeService.GetAll();

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult<WorkoutTypeOutputModel>> Edit(WorkoutTypeEditModel model)
        {
            var result = await workoutTypeService.Edit(model);
            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<WorkoutTypeOutputModel>> Create(WorkoutTypeCreateModel model)
            => await workoutTypeService.Create(model);

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult<Result>> Delete(int id)
            => await workoutTypeService.Delete(id);
    }
}
