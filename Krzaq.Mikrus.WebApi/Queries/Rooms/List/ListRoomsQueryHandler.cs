using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.List
{
    public class ListRoomsQueryHandler(
        IHttpContextAccessor contextAccessor,
        IDbRoomAccess roomAccess)
        : IRequestHandler<ListRoomsQuery, ListRoomsQueryResult>
    {
        public async ValueTask<ListRoomsQueryResult> Handle(ListRoomsQuery request)
        {
            if (request.OnlyJoined)
            {
                int userId = contextAccessor.GetUser()!.GetId();
                var joinedRooms = await roomAccess.GetJoinedRoomsList(userId, request.GameId);
                return new ListRoomsQueryResult { Rooms = joinedRooms };
            }

            var rooms = await roomAccess.GetRoomsList(request.GameId);
            return new ListRoomsQueryResult { Rooms = rooms };
        }
    }
}
