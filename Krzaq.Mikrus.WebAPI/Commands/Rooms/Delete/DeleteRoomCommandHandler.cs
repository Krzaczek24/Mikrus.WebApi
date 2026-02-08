using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Delete
{
    public class DeleteRoomCommandHandler(
        IHttpContextAccessor contextAccessor,
        IDbRoomAccess roomAccess)
        : IRequestHandler<DeleteRoomCommand, DeleteRoomCommandResult>
    {
        public async ValueTask<DeleteRoomCommandResult> Handle(DeleteRoomCommand request)
        {
            var user = contextAccessor.GetUser();
            if (!await roomAccess.IsOwner(request.RoomId, user!.GetId()))
                throw new ForbiddenException();

            await roomAccess.DeleteRoom(request.RoomId);
            return new DeleteRoomCommandResult();
        }
    }
}
