using AMBUS.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Infrastructure.Data.Seeding
{
    public class AdminSeeder
    {
        public static async Task Seed(
            UserManager<AppUser> userManager,
            IConfiguration config
            )
        {
            var adminEmail = config["AdminSeed:Email"];

            if(await userManager.FindByEmailAsync(adminEmail) !=null)
                {
                return;
            }

            var admin = new AppUser
            {

                UserName = config["AdminSeed:Email"], 
                Email = config["AdminSeed:Email"],
                Address = "Main Office",
                EmailConfirmed = true

            };

            var result = await userManager.CreateAsync(admin, config["AdminSeed:Password"]!);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "admin");

        }
    }
}
