using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolManagment.Services.Abstracts
{
    public interface IAuthenticationService
    {

        Task<JwtAuthModel> GenerateJWTTokenWithRefreshToken(ApplicationUser user);
        Task<JwtAuthModel> GetRefreshToken(string accessToken, string refreshToken);
        Task<bool> ValidateAccessToken(string accessToken);
        JwtSecurityToken ReadJwtToken(string accessToken);

    }
}
