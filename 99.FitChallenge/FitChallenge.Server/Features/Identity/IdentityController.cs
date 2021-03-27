using System.Threading.Tasks;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FitChallenge.Server.Features.Identity
{
    [AllowAnonymous]
    public class IdentityController :ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService TokenGeneratorService;

        public IdentityController(UserManager<User> userManager, ITokenGeneratorService identityService)
        {
            this.userManager = userManager;
            this.TokenGeneratorService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequest model)
        {
            var user = new User { Email = model.Email, UserName = model.Email };

            var result = await this.userManager.CreateAsync(user, model.Password);

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
            var user = await this.userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var roles = await userManager.GetRolesAsync(user);
            var encryptedToken = this.TokenGeneratorService.GenerateJwtToken(user.UserName, user.Id, roles);

            return new LoginResponse { Token = encryptedToken };
        }
    }
}
