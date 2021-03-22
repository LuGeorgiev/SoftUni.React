using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitChallenge.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultDbConfiguration(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(appSettingsConfig);

            return appSettingsConfig.Get<AppSettings>();
        }
    }
}
