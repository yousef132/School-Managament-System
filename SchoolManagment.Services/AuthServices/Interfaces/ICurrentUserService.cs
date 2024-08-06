using SchoolManagment.Data.Entities.Identity;

namespace SchoolProject.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
