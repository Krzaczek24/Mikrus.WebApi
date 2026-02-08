using Krzaq.Mikrus.Database.Entities.UserSerssions;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.Logout
{
    public class LogoutCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        IDbUserSessionAccess userSessionAccess)
        : IRequestHandler<LogoutCommand, LogoutCommandResult>
    {
        public async ValueTask<LogoutCommandResult> Handle(LogoutCommand request)
        {
            string login = httpContextAccessor.GetUser()!.GetLogin()!;
            string? clientIp = request.AllMachines
                ? httpContextAccessor.GetClientIp()
                : null;
            await userSessionAccess.RemoveRefreshTokens(login, clientIp);
            return new LogoutCommandResult();
        }
    }
}
