using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public readonly record struct SignInCommand(
        string Login,
        string PasswordHash)
        : IRequest<SignInCommandResult>
    {
        public void Deconstruct(
            out string login,
            out string passwordHash)
        {
            login = Login;
            passwordHash = PasswordHash;
        }
    }
}
