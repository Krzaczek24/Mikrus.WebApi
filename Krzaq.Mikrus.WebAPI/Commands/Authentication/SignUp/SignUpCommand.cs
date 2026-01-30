using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public readonly record struct SignUpCommand()
        : IRequest<SignUpCommandResult>
    {
    }
}
