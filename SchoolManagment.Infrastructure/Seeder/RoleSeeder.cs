using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Infrastructure.Seeder
{
    public class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            if (await _roleManager.Roles.CountAsync() == 0)
            {
                await _roleManager.CreateAsync(new Role(Roles.Admin));

                await _roleManager.CreateAsync(new Role(Roles.User));

            }
        }
    }
}
