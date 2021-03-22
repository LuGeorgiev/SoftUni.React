using System.Security.Claims;
using FitChallenge.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace FitChallenge.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => this.user = httpContextAccessor.HttpContext?.User;


        public string GetId()
            => this.user?.GetId();

        public string GetName()
            => this.user
            ?.Identity
            ?.Name;
    }
}
