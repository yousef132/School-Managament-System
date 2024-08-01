using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;

namespace SchoolManagment.Services.Abstracts
{
    public interface IAuthenticationService
    {

        Task<JwtAuthModel> GenerateJWTTokenWithRefreshToken(ApplicationUser user);

        Task<JwtAuthModel> GetRefreshToken(string accessToken, string refreshToken);
        Task<bool> ValidateAccessToken(string accessToken);

    }
}
