using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenCommandResult>
    {
        public string RefreshToken { get; init; } = string.Empty;
    }
}
