using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public class GameRoomsQueryHandler(IDbRoomAccess roomAccess) : IRequestHandler<GameRoomsQuery, GameRoomsQueryResult>
    {
        public async ValueTask<GameRoomsQueryResult> Handle(GameRoomsQuery request)
        {
            return new() { Rooms = await roomAccess.GetRoomsList(request.GameId) };
        }
    }
}
