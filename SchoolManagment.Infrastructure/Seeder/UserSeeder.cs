using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Infrastructure.Seeder
{
    public static class UserSeeder
    {

        public async static Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.Users.CountAsync() == 0)
            {

                var defaultUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "schoolProject",
                    PhoneNumber = "123456",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(defaultUser, "Aa@123.123");
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin);
            }
        }
    }
}
