using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.GetDetails
{
    public class GetRoomDetailsQueryHandler(
        IHttpContextAccessor contextAccessor,
        IDbRoomAccess roomAccess)
        : IRequestHandler<GetRoomDetailsQuery, GetRoomDetailsQueryResult>
    {
        public async ValueTask<GetRoomDetailsQueryResult> Handle(GetRoomDetailsQuery request)
        {
            int userId = contextAccessor.GetUser()!.GetId();
            if (!await roomAccess.CanEnter(request.RoomId, userId))
                throw new ForbiddenException();

            var roomDetails = await roomAccess.GetRoomDetails(request.RoomId);
            return new GetRoomDetailsQueryResult { Room = roomDetails };
        }
    }
}
