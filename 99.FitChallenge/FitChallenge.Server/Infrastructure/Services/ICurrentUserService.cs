namespace FitChallenge.Server.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetName();

        string GetId();
    }
}
