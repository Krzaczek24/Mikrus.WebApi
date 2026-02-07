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
                throw new UnauthorizedException(ErrorCode.InvalidLoginOrPassword);

            await userAccess.UpdateLastLoginDate(request.Login);
            var user = (await userAccess.GetUser(request.Login)).Value;

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
