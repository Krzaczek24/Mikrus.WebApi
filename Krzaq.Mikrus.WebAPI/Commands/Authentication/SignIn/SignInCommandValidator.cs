using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public class SignInCommandValidator : RequestValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(x => x.Login).Required();
            RuleFor(x => x.Password).Required();
        }
    }
}
