using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.WebApi.Shared.Constants;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Krzaq.Mikrus.WebApi.Core.Authorization.Token
{
    public class TokenBuilder(string key)
    {
        private const string DATE_FORMAT = StringFormats.Dates.ISO_8601;

        private SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

        public string GenerateAccessToken(UserDto user)
        {
            DateTime now = DateTime.UtcNow;

            var userClaims = new List<Claim>
            {
                new CustomClaim(UserClaim.Id, user.Id.ToString()),
                new CustomClaim(UserClaim.Login, user.Login),
                new CustomClaim(UserClaim.DisplayName, user.DisplayName),
                //new CustomClaim(UserClaim.Role, user.Role.ToString().ToUpper()),
                //new CustomClaim(UserClaim.FirstName, user.FirstName ?? string.Empty),
                //new CustomClaim(UserClaim.LastName, user.LastName ?? string.Empty),
                new CustomClaim(UserClaim.CreatedAt, user.CreatedAt.ToString(DATE_FORMAT)),
                new CustomClaim(UserClaim.CurrentLoginDate, now.ToString(DATE_FORMAT)),
                new CustomClaim(UserClaim.LastLoginDate, user.LastLogin?.ToString(DATE_FORMAT) ?? string.Empty),
            };

            //if (user.Permissions?.Length > 0)
            //{
            //    userClaims.AddRange(user.Permissions.Select(permission => new CustomClaim(UserClaim.Permissions, permission)));
            //}

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(userClaims, null, UserClaim.Login.ToString().ToCamelCase(), null), //UserClaim.Role.ToString().ToCamelCase()
                IssuedAt = now,
#if DEBUG
                Expires = now.Add(TimeSpan.FromDays(42)),
#else
                Expires = now.Add(TimeSpan.FromMinutes(5)),
#endif
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature),
            };
            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        public string GenerateRefreshToken(out DateTime? validUntil)
        {
            DateTime now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                IssuedAt = now,
                Expires = validUntil = now.Add(TimeSpan.FromDays(7)),
                SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512Signature),
            };
            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }

        public static bool IsRefreshTokenValid(string refreshToken)
        {
            var tokenHandler = new JsonWebTokenHandler();

            if (!tokenHandler.CanReadToken(refreshToken))
                return false;

            var tokenData = tokenHandler.ReadJsonWebToken(refreshToken);

            return tokenData.ValidTo > DateTime.UtcNow;
        }
    }
}
