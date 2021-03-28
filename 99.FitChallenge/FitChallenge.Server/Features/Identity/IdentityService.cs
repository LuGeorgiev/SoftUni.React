using System.Linq;
using System.Threading.Tasks;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Identity;

using static FitChallenge.Server.WebConstants.Identity;

namespace FitChallenge.Server.Features.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService tokenGeneratorService;

        public IdentityService(UserManager<User> userManager, ITokenGeneratorService tokenGeneratorService)
        {
            this.userManager = userManager;
            this.tokenGeneratorService = tokenGeneratorService;
        }

        public async Task<Result> ChangePassword(ChangePasswordRequest changePasswordInput)
        {
            var user = await this.userManager.FindByEmailAsync(changePasswordInput.Email);
            if (user == null)
            {
                return InvalidCredentials;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user, 
                changePasswordInput.OldPassword, 
                changePasswordInput.NewPassword);
            var errors = identityResult.Errors.Select(x => x.Description);

            return identityResult.Succeeded
                ? Result.Success
                :Result.Failure(errors);
        }

        public async Task<Result<LoginResponse>> Login(LoginRequest userInput)
        {
            var user = await this.userManager.FindByNameAsync(userInput.Email);
            if (user == null)
            {
                return InvalidCredentials;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidCredentials;
            }

            var roles = await userManager.GetRolesAsync(user);
            var encryptedToken = this.tokenGeneratorService.GenerateJwtToken(user.UserName, user.Id, roles);

            return new LoginResponse { Token = encryptedToken };
        }

        public async Task<Result> Register(RegisterRequest userInput)
        {
            var user = new User { Email = userInput.Email, UserName = userInput.Email };

            var result = await this.userManager.CreateAsync(user, userInput.Password);
            var errors = result.Errors.Select(x => x.Description);

            return result.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
    }
}
