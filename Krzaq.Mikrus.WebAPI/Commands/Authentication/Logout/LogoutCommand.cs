using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.Logout
{
    public readonly record struct LogoutCommand(
        bool AllMachines)
        : IRequest<LogoutCommandResult>;
}
