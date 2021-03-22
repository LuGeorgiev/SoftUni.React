using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitChallenge.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

using static FitChallenge.Server.WebConstants.DataSeed;

namespace FitChallenge.Server.Data.Seed
{
    public class DataSeeder : IDataSeeder
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppSettings appSettings;

        public DataSeeder(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager,
            IOptions<AppSettings> options)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.appSettings = options.Value;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                Task.Run(async () =>
                {
                    var adminRole = new IdentityRole(AdministratorRoleName);
                    await this.roleManager.CreateAsync(adminRole);

                    var moderatorRole = new IdentityRole(ModeratorRoleName);
                    await this.roleManager.CreateAsync(moderatorRole);

                    var adminUser = new User
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        SecurityStamp = "SomeStamp"
                    };

                    await this.userManager.CreateAsync(adminUser, this.appSettings.AdminPassword);
                    await this.userManager.AddToRolesAsync(adminUser, new List<string> { AdministratorRoleName, ModeratorRoleName });
                })
                .GetAwaiter()
                .GetResult();
            }

            Task
                .Run(async () =>
                {
                    if (await this.userManager.FindByIdAsync(DefaultUserId) != null)
                    {
                        return;
                    }

                    var defaultUser = new User
                    {
                        Id = DefaultUserId,
                        UserName = "test@test.com",
                        Email = "test@test.com"
                    };

                    await this.userManager.CreateAsync(defaultUser, DefaultUserPassword);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
