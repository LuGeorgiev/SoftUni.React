using FitChallenge.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitChallenge.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetRequiredService<FitChallengeDbContext>();

            dbContext.Database.Migrate();
        }

        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
            => app.UseSwagger()
                .UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FitChallenge.Server v1");
                    c.RoutePrefix = string.Empty;
                });
    }
}
