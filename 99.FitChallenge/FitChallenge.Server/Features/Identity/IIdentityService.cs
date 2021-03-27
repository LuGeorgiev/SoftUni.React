using System.Threading.Tasks;
using FitChallenge.Server.Features.Identity.Models;

namespace FitChallenge.Server.Features.Identity
{
    public interface IIdentityService
    {
        Task<Result> Register(RegisterRequest userInput);

        Task<Result<LoginResponse>> Login(LoginRequest userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordRequest changePasswordInput);
    }
}
