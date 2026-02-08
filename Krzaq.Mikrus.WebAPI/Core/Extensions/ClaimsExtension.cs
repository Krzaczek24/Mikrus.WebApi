using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.WebApi.Core.Authorization;
using System.Security.Claims;

namespace Krzaq.Mikrus.WebApi.Core.Extensions
{
    public static class ClaimsExtension
    {
        public static int GetId(this ClaimsPrincipal claims) => claims.Get<int>(UserClaim.Id);
        public static string GetLogin(this ClaimsPrincipal claims) => claims.Get(UserClaim.Login)!;
        //public static string GetRole(this ClaimsPrincipal claims) => claims.Get(UserClaim.Role)!;

        public static string? Get(this ClaimsPrincipal claims, UserClaim userClaim) => Get(claims, userClaim.ToString().ToCamelCase());

        private static string? Get(this ClaimsPrincipal claims, string userClaim)
        {
            try { return claims.Claims.SingleOrDefault(claim => claim.Type == userClaim)?.Value; }
            catch { throw new KeyNotFoundException($"Found more than one value for [{userClaim}] key in user claims set"); }
        }

        public static T? Get<T>(this ClaimsPrincipal claims, UserClaim userClaim)
        {
            string? value = claims.Get(userClaim);
            try { return (T?)Convert.ChangeType(value, typeof(T)); }
            catch { throw new InvalidCastException($"Cannot convert user [{userClaim}] claim value [{value}] from [{value?.GetType().Name}] to [{typeof(T).Name}] type"); }
        }

        public static IReadOnlyCollection<string> GetMany(this ClaimsPrincipal claims, UserClaim userClaim)
            => GetMany(claims, userClaim.ToString().ToCamelCase()).ToList().AsReadOnly();

        private static IEnumerable<string> GetMany(this ClaimsPrincipal claims, string userClaim)
            => claims.Claims.Where(claim => claim.Type == userClaim).Select(claim => claim.Value);

        public static IReadOnlyCollection<T> GetMany<T>(this ClaimsPrincipal claims, UserClaim userClaim)
        {
            try { return claims.GetMany(userClaim.ToString().ToCamelCase()).Cast<T>().ToList().AsReadOnly(); }
            catch { throw new InvalidCastException($"Cannot convert user [{userClaim}] claim value collection from [{typeof(string).Name}] to [{typeof(T).Name}] type"); }
        }
    }
}
