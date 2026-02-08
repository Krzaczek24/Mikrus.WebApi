using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandValidator : RequestValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Login)
                .Required();

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .Required()
                .Sha512();
        }
    }
}
