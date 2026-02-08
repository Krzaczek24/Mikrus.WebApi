using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Join
{
    public class JoinRoomCommandValidator : RequestValidator<JoinRoomCommand>
    {
        public JoinRoomCommandValidator()
        {
            RuleFor(x => x.RoomId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField)
                .GreaterThan(0)
                .WithErrorCode(ErrorCode.NonPositiveValue);
        }
    }
}
