using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Delete
{
    public class DeleteRoomCommandValidator : RequestValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
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
