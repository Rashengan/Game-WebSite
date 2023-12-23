using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app){
            var Icontext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();
            if (Icontext.Database.GetAppliedMigrations().Any())
            {
                Icontext.Database.Migrate();
            }

            var UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await UserManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new AppUser{
                    UserName = adminUser,
                    FullName = "admin admin",
                    Email = "admin@deniz.com",
                    PhoneNumber = "12345678912"
                };

                await UserManager.CreateAsync(user, adminPassword);
            }
        }
    }
}