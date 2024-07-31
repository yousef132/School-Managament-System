using SchoolManagment.Data.Entities.Identity;

namespace SchoolManagment.Services.Abstracts
{
    public interface IAuthenticationService
    {

        Task<string> GenerateJWTToken(ApplicationUser user);


    }
}
