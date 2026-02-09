using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.ListGame
{
    public class ListGameRoomsQueryHandler(IDbRoomAccess roomAccess) : IRequestHandler<ListGameRoomsQuery, ListGameRoomsQueryResult>
    {
        public async ValueTask<ListGameRoomsQueryResult> Handle(ListGameRoomsQuery request)
        {
            var rooms = await roomAccess.GetRoomsList(request.GameId);
            return new ListGameRoomsQueryResult { Rooms = rooms };
        }
    }
}
