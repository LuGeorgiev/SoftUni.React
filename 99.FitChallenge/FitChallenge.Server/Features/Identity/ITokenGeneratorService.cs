using System.Collections.Generic;

namespace FitChallenge.Server.Features.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateJwtToken(string userName, string userId, IEnumerable<string> roles = null);
    }
}
