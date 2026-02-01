using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public readonly record struct SignInCommand(
        string Login,
        string Password)
        : IRequest<SignInCommandResult>
    {
        public void Deconstruct(
            out string login,
            out string password)
        {
            login = Login;
            password = Password;
        }
    }
}
