using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken
{
    public readonly record struct RefreshTokenCommand(
        string RefreshToken)
        : IRequest<RefreshTokenCommandResult>;
}
