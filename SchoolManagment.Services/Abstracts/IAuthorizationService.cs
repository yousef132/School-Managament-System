using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Requests;
using SchoolManagment.Data.Responses;

namespace SchoolManagment.Services.Abstracts
{
    public interface IAuthorizationService
    {
        Task<bool> AddRoleAsync(string RoleName);
        Task<bool> IsRoleExistsAsync(string RoleName);
        Task<bool> EditRoleAsync(EditRoleRequest request);
        Task<List<Role>> GetRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task<ManageUserRolesResponse?> GetUserWithRolesAsync(int userId);
        Task<ManageUserClaimsResponse?> GetUserWithClaimsAsync(int userId);
        Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        Task<bool> DeleteRole(int roleId);

        Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request);
    }
}
