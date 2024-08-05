using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Services.Abstracts
{
    public interface IUserService
    {
        Task<string> AddUserAsync(ApplicationUser user, string password);
    }
}
