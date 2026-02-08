using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public class GameRoomsQueryHandler(IDbRoomAccess roomAccess) : IRequestHandler<GameRoomsQuery, GameRoomsQueryResult>
    {
        public async ValueTask<GameRoomsQueryResult> Handle(GameRoomsQuery request)
        {
            var rooms = await roomAccess.GetRoomsList(request.GameId);
            return new GameRoomsQueryResult { Rooms = rooms };
        }
    }
}
