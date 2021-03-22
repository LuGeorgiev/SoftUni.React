using System.Linq;
using System.Security.Claims;

namespace FitChallenge.Server.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user
            .Claims
            .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)
            ?.Value;
    }
}
