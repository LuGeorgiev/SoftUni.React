using System;
using System.Reflection;
using System.Text;
using FitChallenge.Server.Data;
using FitChallenge.Server.Data.Models;
using FitChallenge.Server.Data.Seed;
using FitChallenge.Server.Features.Identity;
using FitChallenge.Server.Infrastructure.Filters;
using FitChallenge.Server.Infrastructure.Mapping;
using FitChallenge.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FitChallenge.Server.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<FitChallengeDbContext>(opt => opt.UseSqlServer(configuration.GetDefaultDbConfiguration()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<FitChallengeDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt =>
                {
                    jwt.RequireHttpsMetadata = false;
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection sercices)
            => sercices
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IDataSeeder, DataSeeder>()
                .AddScoped<ITokenGeneratorService, TokenGeneratorService>()
                .AddScoped<IIdentityService, IdentityService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FitChallenge.Server", Version = "v1" });
            });

        public static IServiceCollection AddAutoMapperProfile(this IServiceCollection services, Assembly assembly)
            => services
            .AddAutoMapper((_, config) => 
                config.AddProfile(new MappingProfile(assembly)),
            Array.Empty<Assembly>());


        public static void AddApiControllers(this IServiceCollection services)
            => services.AddControllers(opt => opt.Filters.Add<ModelOrNotFoundActionFilter>());
    }
}
