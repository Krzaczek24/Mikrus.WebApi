using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.Get
{
    public class GetRoomQueryHandler(
        IHttpContextAccessor contextAccessor,
        IDbRoomAccess roomAccess)
        : IRequestHandler<GetRoomQuery, GetRoomQueryResult>
    {
        public async ValueTask<GetRoomQueryResult> Handle(GetRoomQuery request)
        {
            int userId = contextAccessor.GetUser()!.GetId();
            if (!await roomAccess.CanEnter(request.RoomId, userId))
                throw new ForbiddenException();

            var roomDetails = await roomAccess.GetRoomDetails(request.RoomId);
            return new GetRoomQueryResult { Room = roomDetails };
        }
    }
}
