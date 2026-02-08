using Krzaq.Mikrus.Database.Entities.Room;
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
            if (!await roomAccess.CanEnter(request.RoomId, userId))
                throw new ForbiddenException();

            await roomAccess.JoinRoom(request.RoomId, userId);
            return new JoinRoomCommandResult();
        }
    }
}
