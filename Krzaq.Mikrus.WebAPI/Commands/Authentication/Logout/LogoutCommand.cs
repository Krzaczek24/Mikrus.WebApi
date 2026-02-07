using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.Logout
{
    public class LogoutCommand : IRequest<LogoutCommandResult>
    {
        public bool AllMachines { get; init; }
    }
}
