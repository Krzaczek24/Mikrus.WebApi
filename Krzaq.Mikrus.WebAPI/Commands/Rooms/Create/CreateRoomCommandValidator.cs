using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Create
{
    public class CreateRoomCommandValidator : RequestValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.GameId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.NonPositiveValue);

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .MaximumLength(32)
                .WithErrorCode(ErrorCode.ValueTooLong, 32);

            RuleFor(x => x.MinPlayers)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.NonPositiveValue);

            RuleFor(x => x.MaxPlayers)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.NonPositiveValue)
                .GreaterThanOrEqualTo(x => x.MinPlayers)
                .WithErrorCode(ErrorCode.LesserThanOtherField, nameof(CreateRoomCommand.MinPlayers));

            RuleFor(x => x.ExpireDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .GreaterThan(DateTime.Now.AddMinutes(5))
                .WithErrorCode(ErrorCode.DateFromPast);

            When(x => x.Password is not null, () =>
            {
                RuleFor(x => x.Password)
                    .Matches(@"[a-z0-9]{128}")
                    .WithErrorCode(ErrorCode.InvalidSha512);
            });
        }
    }
}
