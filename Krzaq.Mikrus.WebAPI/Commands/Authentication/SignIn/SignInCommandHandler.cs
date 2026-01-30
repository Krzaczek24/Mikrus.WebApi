using Krzaq.Exceptions.Http;
using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.WebApi.Core.Authorization.Token;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public class SignInCommandHandler(IDbUserAccess userAccess) : IHandler<SignInCommand, SignInCommandResult>
    {
        public async ValueTask<SignInCommandResult> Handle(SignInCommand request)
        {
            var (login, passwordHash) = request;

            if (!await userAccess.AuthenticateUser(login, passwordHash))
                throw new UnauthorizedException();

            await userAccess.UpdateLastLoginDate(login);
            var user = await userAccess.GetUser(login);

            try
            {
                return await GenerateTokens(user!, userAccess.SaveNewRefreshToken);
            }
            catch (DuplicatedEntryException)
            {
                throw new ConflictException(ErrorCode.TokenExists);
            }
        }

        private async ValueTask<SignInCommandResult> GenerateTokens(DbUser user, Func<string, string?, string, DateTime?, ValueTask> refreshTokenFunc)
        {
            var tokenBuilder = new TokenBuilder(Configuration[ConfigurationKeys.ApiKey]!);
            string refreshToken = tokenBuilder.GenerateRefreshToken(out DateTime? validUntil);
            var saveRefreshTokenTask = refreshTokenFunc(user.Login, HttpContext.GetClientIp(), refreshToken, validUntil);
            string accessToken = tokenBuilder.GenerateAccessToken(user);
            await saveRefreshTokenTask;

            return new (accessToken, refreshToken);
        }
    }
}
