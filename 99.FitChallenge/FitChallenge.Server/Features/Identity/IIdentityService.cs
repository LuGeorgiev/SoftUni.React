namespace FitChallenge.Server.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userName, string userId, string secret);
    }
}
