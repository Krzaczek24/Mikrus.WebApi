using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.Logout
{
    public record class LogoutCommand : IRequest<LogoutCommandResult>
    {
        public bool AllMachines { get; init; }
    }
}
