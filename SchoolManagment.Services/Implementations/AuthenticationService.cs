using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Services.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagment.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWT jwt;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
        {
            this.userManager = userManager;
            this.jwt = jwt.Value;
        }
        public async Task<string> GenerateJWTToken(ApplicationUser user)
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var userClaims = await userManager.GetClaimsAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in userRoles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(roleClaims)
            .Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(jwt.DurationInDays)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
