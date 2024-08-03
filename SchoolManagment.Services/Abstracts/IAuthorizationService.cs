using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Requests;

namespace SchoolManagment.Services.Abstracts
{
    public interface IAuthorizationService
    {
        Task<bool> AddRoleAsync(string RoleName);
        Task<bool> IsRoleExistsAsync(string RoleName);
        Task<bool> EditRoleAsync(EditRoleRequest request);
        Task<List<Role>> GetRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
    }
}
