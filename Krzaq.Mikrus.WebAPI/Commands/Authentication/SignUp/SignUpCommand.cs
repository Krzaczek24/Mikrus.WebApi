using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public readonly record struct SignUpCommand(
        string Login,
        string? DisplayName,
        string Password)
        : IRequest<SignUpCommandResult>
    {
        public void Deconstruct(
            out string login,
            out string? displayName,
            out string password)
        {
            login = Login;
            displayName = DisplayName;
            password = Password;
        }
    }
}
