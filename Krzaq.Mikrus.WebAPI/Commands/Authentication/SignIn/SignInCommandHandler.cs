using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Entities.UserSerssions;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Core.Providers;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public class SignInCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        IJwtTokenPovider tokenProvider,
        IDbUserAccess userAccess,
        IDbUserSessionAccess userSessionAccess)
        : IRequestHandler<SignInCommand, SignInCommandResult>
    {
        public async ValueTask<SignInCommandResult> Handle(SignInCommand request)
        {
            if (!await userAccess.IsUserDataCorrect(request.Login, request.Password))
                throw new UnauthorizedException(ErrorCode.Unauthorized);

            await userAccess.UpdateLastLoginDate(request.Login);
            var user = await userAccess.GetUser(request.Login);

            string refreshToken = tokenProvider.GenerateRefreshToken(out DateTime? validUntil);
            string? clientIp = httpContextAccessor.GetClientIp();
            var saveRefreshTokenTask = userSessionAccess.SaveNewRefreshToken(request.Login, clientIp, refreshToken, validUntil);
            string accessToken = tokenProvider.GenerateAccessToken(user.Value);
            await saveRefreshTokenTask;

            return new SignInCommandResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
