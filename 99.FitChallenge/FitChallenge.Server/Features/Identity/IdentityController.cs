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
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> options, IIdentityService identityService)
        {
            this.userManager = userManager;
            this.appSettings = options.Value;
            this.identityService = identityService;
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

            var encryptedToken = this.identityService.GenerateJwtToken(user.UserName, user.Id, appSettings.Secret);

            return new LoginResponse { Token = encryptedToken };
        }
    }
}
