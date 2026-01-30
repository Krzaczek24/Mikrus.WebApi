using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandHandler : IHandler<SignUpCommand, SignUpCommandResult>
    {
        public ValueTask<SignUpCommandResult> Handle(SignUpCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
