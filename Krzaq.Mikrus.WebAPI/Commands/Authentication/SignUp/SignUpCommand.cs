using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public record class SignUpCommand : IRequest<SignUpCommandResult>
    {
        public string Login { get; init; } = string.Empty;
        public string? DisplayName { get; init; }
        public string Password { get; init; } = string.Empty;
    }
}
