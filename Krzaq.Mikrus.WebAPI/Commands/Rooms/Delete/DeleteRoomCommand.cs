using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Delete
{
    public record class DeleteRoomCommand : IRequest<DeleteRoomCommandResult>
    {
        public int RoomId { get; init; }
    }
}
