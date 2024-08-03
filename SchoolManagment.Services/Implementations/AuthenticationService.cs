using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Data.Helper;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Services.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagment.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly JWT jwt;

        public AuthenticationService(UserManager<ApplicationUser> userManager
                                    , IOptions<JWT> jwt
                                    , IRefreshTokenRepository refreshTokenRepository)
        {
            this.userManager = userManager;
            this.refreshTokenRepository = refreshTokenRepository;
            this.jwt = jwt.Value;
        }


        // must be called when register or login
        public async Task<JwtAuthModel> GenerateJWTTokenWithRefreshToken(ApplicationUser user)
        {
            #region Generate Jwt

            var jwtToken = await GenerateJWTToken(user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            #endregion


            var refreshToken = new RefreshToken
            {
                ExpiresOn = DateTime.UtcNow.AddDays(jwt.RefreshTokenExpiration),
                UserName = user.UserName,
                Token = GenerateRefreshToken()
            };

            #region Generate User Refresh Token And Save it in db

            var userRefreshToken = new UserRefreshToken
            {
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(jwt.RefreshTokenExpiration),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.Token,
                Token = accessToken,
                UserId = user.Id
            };
            await refreshTokenRepository.AddAsync(userRefreshToken);
            #endregion

            #region Return AuthModel (access & refresh tokens)

            return new JwtAuthModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            #endregion
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(ApplicationUser user)
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
                new Claim("userId", user.Id.ToString())
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
                expires: DateTime.UtcNow.AddDays(jwt.AccessTokenExpiration)
            );
            return jwtToken;
        }
        public async Task<JwtAuthModel> GetRefreshToken(string accessToken, string refreshToken)
        {
            // refresh token 
            #region Read And Validate Access Token  
            var jwtSecurityToken = ReadJwtToken(accessToken);



            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "userId").Value;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                throw new SecurityTokenException("Invalid User Id");

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                throw new SecurityTokenException("Algorithm Is Wrong");

            if (jwtSecurityToken.ValidTo > DateTime.UtcNow)
                throw new SecurityTokenException("Access Token Is Not Expired");

            #endregion

            #region Read And Validate Refresh Token  

            var userRefreshTokenRecord = await refreshTokenRepository
                        .GetTableAsNotTracked()
                        .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                             x.RefreshToken == refreshToken &&
                                             x.UserId == int.Parse(userId));

            if (userRefreshTokenRecord == null)
                throw new SecurityTokenException("Invalid Refresh Token Operation");

            if (userRefreshTokenRecord.ExpiryDate < DateTime.UtcNow)
            {
                // refresh token is expired
                // revoke refresh token
                userRefreshTokenRecord.IsRevoked = true;
                userRefreshTokenRecord.IsUsed = false;
                await refreshTokenRepository.UpdateAsync(userRefreshTokenRecord);
                throw new SecurityTokenException("Refresh Token Is Expired");
            }
            #endregion

            // right here you have a valid refresh token with an invalid access token

            //  update the access token of the current refresh token record
            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJWTToken(user));

            userRefreshTokenRecord.Token = newAccessToken;
            await refreshTokenRepository.UpdateAsync(userRefreshTokenRecord);

            var refreshTokenResult = new RefreshToken
            {
                UserName = user.UserName,
                Token = refreshToken,
                ExpiresOn = userRefreshTokenRecord.ExpiryDate
            };

            return new JwtAuthModel
            {
                RefreshToken = refreshTokenResult,
                AccessToken = newAccessToken
            };
        }
        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
            //bool tokenValidationResult = await ValidateToken(accessToken);
            //if (!tokenValidationResult)
            //    throw new SecurityTokenInvalidSignatureException();
            //return validatedToken;

        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<bool> ValidateAccessToken(string accessToken)
        {


            var handler = new JwtSecurityTokenHandler();
            var parameters = GetValidationParameters();

            try
            {
                handler.ValidateToken(accessToken, parameters, out _);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = jwt.Issuer,
                ValidAudience = jwt.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                ClockSkew = TimeSpan.Zero
            };
        }

    }
}
