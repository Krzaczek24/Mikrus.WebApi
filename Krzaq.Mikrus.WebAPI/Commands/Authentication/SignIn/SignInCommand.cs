using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public record class SignInCommand : IRequest<SignInCommandResult>
    {
        public string Login { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
