using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Requests;
using SchoolManagment.Data.Responses;
using SchoolManagment.Infrastructure.InfrastructureBases;
using SchoolManagment.Services.Abstracts;
using Serilog;
using System.Security.Claims;

namespace SchoolManagment.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGenericRepository<Role> genericRepository;


        #region Fields

        #endregion

        #region Constructor
        public AuthorizationService(RoleManager<Role> roleManager,
                                    UserManager<ApplicationUser> userManager,
                                    IGenericRepository<Role> genericRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.genericRepository = genericRepository;
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

        public async Task<string> UpdateUserRoles(UpdateUserRolesRequest request)
        {
            var transaction = genericRepository.BeginTransaction();
            try
            {

                var user = await userManager.FindByIdAsync(request.UserId.ToString());

                if (user == null)
                    return "UserIsNull";

                foreach (var role in request.Roles)
                    if (roleManager.Roles.Any(r => r.Id != role.Id && r.Name != role.Name))
                        return "InvalidRole";

                var userRoles = await userManager.GetRolesAsync(user);
                var removeResult = await userManager.RemoveFromRolesAsync(user, userRoles);
                if (!removeResult.Succeeded)
                    return "FailedToRemoveOldRoles";


                var selectedRoles = request.Roles.Where(r => r.HasRole).Select(r => r.Name).ToList();

                var addResult = await userManager.AddToRolesAsync(user, selectedRoles);

                if (!addResult.Succeeded)
                    return "FailedToAddNewRoles";

                genericRepository.Commit();
                return "Success";


            }
            catch (Exception ex)
            {
                Log.Error("Error While Updating User Roles", ex.Message);

                genericRepository.RollBack();
                return "FailedToUpdateUserRoles";
            }
        }

        public async Task<ManageUserClaimsResponse?> GetUserWithClaimsAsync(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return null;

            var userClaims = await userManager.GetClaimsAsync(user);
            var claims = ClaimsStore.Claims.Select(claim => new UserClaims
            {
                Type = claim.Type,
                Value = userClaims.Any(uc => uc.Type == claim.Type)
            }).ToList();

            return new ManageUserClaimsResponse
            {
                UserId = userId,
                Claims = claims
            };
        }

        public async Task<bool> DeleteRole(int roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
                return false;
            var result = await roleManager.DeleteAsync(role);

            return result.Succeeded;
        }

        public async Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request)
        {
            using var transaction = genericRepository.BeginTransaction();
            try
            {
                var user = await userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return "UserNotFound";

                // Remove old claims
                var userClaims = await userManager.GetClaimsAsync(user);

                var removeClaimsResult = await userManager.RemoveClaimsAsync(user, userClaims);


                if (!removeClaimsResult.Succeeded)
                    return "FailedToRemoveOldClaims";


                // Add new claims
                var newClaims = request.Claims
                    .Where(x => x.Value)
                    .Select(x => new Claim(x.Type, x.Value.ToString()));

                var addClaimsResult = await userManager.AddClaimsAsync(user, newClaims);
                if (!addClaimsResult.Succeeded)
                    return "FailedToAddNewClaims";

                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                Log.Error("Error While Updating User Claims", ex.Message);

                await transaction.RollbackAsync();
                return "FailedToUpdateClaims";
            }
        }
        #endregion
    }
}
