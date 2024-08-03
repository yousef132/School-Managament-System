using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Requests;
using SchoolManagment.Services.Abstracts;

namespace SchoolManagment.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        #region Fields

        #endregion

        #region Constructor
        public AuthorizationService(RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        #endregion

        #region Handlers




        public async Task<bool> AddRoleAsync(string roleName)
        {
            var result = await roleManager.CreateAsync(new Role(roleName));
            return result.Succeeded;
        }

        public async Task<bool> EditRoleAsync(EditRoleRequest request)
        {
            var role = await roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
                return false;
            role.Name = request.Name;

            var result = await roleManager.UpdateAsync(role);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
            => await roleManager.FindByIdAsync(id.ToString());

        public Task<List<Role>> GetRolesAsync()
            => roleManager.Roles.ToListAsync();

        public async Task<ManageUserRolesResponse?> GetUserWithRolesAsync(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return null;
            var Roles = new List<UserRole>();
            var response = new ManageUserRolesResponse();


            var userRoles = await userManager.GetRolesAsync(user);

            var roles = await roleManager.Roles.ToListAsync();
            response.UserId = userId;


            foreach (var role in roles)
            {
                Roles.Add(new UserRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    HasRole = userRoles.Contains(role.Name)
                });
            }
            response.Roles = Roles;
            return response;
        }

        public async Task<bool> IsRoleExistsAsync(string roleName)
            => await roleManager.RoleExistsAsync(roleName);

        #endregion
    }
}
