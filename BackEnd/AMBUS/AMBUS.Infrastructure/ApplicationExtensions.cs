using AMBUS.Domain.Models;
using AMBUS.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Infrastructure
{
    public static class ApplicationExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();
            var config = scope.ServiceProvider
                .GetRequiredService<IConfiguration>();

            
            await AdminSeeder.Seed(userManager, config);
            await RoleSeeder.Seed(roleManager);
        }
    }
}
