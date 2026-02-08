using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandValidator : RequestValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Login)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .MaximumLength(64)
                .WithErrorCode(ErrorCode.ValueTooLong, 64);

            RuleFor(x => x.DisplayName)
                .MaximumLength(64)
                .WithErrorCode(ErrorCode.ValueTooLong, 64);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .Matches(@"[a-z0-9]{128}")
                .WithErrorCode(ErrorCode.InvalidSha512);
        }
    }
}
