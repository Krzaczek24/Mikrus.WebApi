using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Entities.UserSerssions;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Core.Providers;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        IJwtTokenPovider tokenProvider,
        IDbUserAccess userAccess,
        IDbUserSessionAccess userSessionAccess)
        : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResult>
    {
        public async ValueTask<RefreshTokenCommandResult> Handle(RefreshTokenCommand request)
        {
            string token = request.RefreshToken;

            if (!tokenProvider.IsRefreshTokenValid(token))
                throw new UnauthorizedException(ErrorCode.TokenExpired);

            var user = await userAccess.GetUser(token, httpContextAccessor.GetClientIp())
                ?? throw new UnauthorizedException(ErrorCode.TokenInvalid);

            string refreshToken = tokenProvider.GenerateRefreshToken(out DateTime? validUntil);
            string? clientIp = httpContextAccessor.GetClientIp();
            var saveRefreshTokenTask = userSessionAccess.SaveNewRefreshToken(user.Login, clientIp, refreshToken, validUntil);
            string accessToken = tokenProvider.GenerateAccessToken(user);
            await saveRefreshTokenTask;

            return new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
