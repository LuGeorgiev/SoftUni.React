using System.Threading.Tasks;
using FitChallenge.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FitChallenge.Server.WebConstants.Identity;

namespace FitChallenge.Server.Features.Identity
{
    [AllowAnonymous]
    public class IdentityController :ApiController
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequest model)
        {

            var result = await this.identityService.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest model)
        {
            var result = await this.identityService.Login(model);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return result;
        }

        [HttpPut]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest model)
            => await this.identityService.ChangePassword(model);

        [HttpPost]
        [Authorize]
        [Authorize]
        [Route(nameof(LogOut))]
        public  ActionResult LogOut()
        {
            this.Response.Cookies.Delete(AuthenticationCookieName);

            return Ok();
        }
    }
}
