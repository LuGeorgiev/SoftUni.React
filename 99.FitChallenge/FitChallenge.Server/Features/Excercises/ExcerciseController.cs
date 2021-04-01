using System.Collections.Generic;
using System.Threading.Tasks;
using FitChallenge.Server.Data.Models.Enums;
using FitChallenge.Server.Features.Excercises.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FitChallenge.Server.Features.Excercises
{
    [AllowAnonymous]
    public class ExcerciseController : ApiController
    {
        private readonly IExcerciseService excerciseService;

        public ExcerciseController(IExcerciseService excerciseService)
        {
            this.excerciseService = excerciseService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ExcerciseOutputModel>> Get(int id)
        {
            var result = await excerciseService.FindById(id);

            return result;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<IEnumerable<ExcerciseOutputModel>>> GetByName(string name)
            => await excerciseService.ContainsName(name);

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<ExcerciseListingModel>>> GetAll()
            => await excerciseService.GetAll();

        [HttpGet]
        [Route(nameof(GetByType))]
        public async Task<ActionResult<IEnumerable<ExcerciseListingModel>>> GetByType(ExcerciseType type)
            => await excerciseService.GetByType(type);

        [HttpPost]
        public async Task<ActionResult<ExcerciseOutputModel>> Create(ExcerciseCreateModel model)
        { 
            var result = await excerciseService.Create(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result.Data;
        }

        [HttpPut]
        public async Task<ActionResult<ExcerciseOutputModel>> Edit(ExcerciseEditModel model)
        {
            var result = await excerciseService.Edit(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result.Data;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Result>> Delete(int id)
        {
            var result = await excerciseService.Delete(id);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result;
        }
    }
}
