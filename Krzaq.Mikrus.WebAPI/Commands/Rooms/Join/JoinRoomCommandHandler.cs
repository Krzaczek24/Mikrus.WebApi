using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Join
{
    public class JoinRoomCommandHandler(
        IHttpContextAccessor contextAccessor,
        IDbRoomAccess roomAccess)
        : IRequestHandler<JoinRoomCommand, JoinRoomCommandResult>
    {
        public async ValueTask<JoinRoomCommandResult> Handle(JoinRoomCommand request)
        {
            int userId = contextAccessor.GetUser()!.GetId();

            if (await roomAccess.CanEnter(request.RoomId, userId))
                throw new ConflictException(ErrorCode.AlreadyJoinedToRoom);

            if (await roomAccess.GetFreeSlots(request.RoomId) <= 0)
                throw new ConflictException(ErrorCode.RoomHasNoFreeSlots);

            if (request.Guid.HasValue)
            {
                if (!await roomAccess.IsGuidUsed(request.Guid.Value))
                    throw new NotFoundException(ErrorCode.NotFound);

                await roomAccess.JoinRoom(request.Guid.Value, userId);
                return new JoinRoomCommandResult();
            }

            if (await roomAccess.IsGoodPassword(request.RoomId, request.Password)
            || await roomAccess.CanJoinAsOwnerFriend(request.RoomId, userId))
            {
                await roomAccess.JoinRoom(request.RoomId, userId);
                return new JoinRoomCommandResult();
            }

            throw new ForbiddenException(ErrorCode.Forbidden);
        }
    }
}
