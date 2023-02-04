using DataLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTest.Seed
{
    public static class IdentitySeed
    {
        

        public static async void Seed(IApplicationBuilder app, IConfiguration configuration)
        {
            CryptoTestContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<CryptoTestContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = 
                app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            string adminUser = configuration.GetSection("AdminUser").Value;
            string adminPassword = configuration.GetSection("AdminPassword").Value;

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "ali.talebi199434@gmail.com";
                user.PhoneNumber = "+989037163785";
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
