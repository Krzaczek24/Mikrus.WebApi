using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public class GameRoomsQuery : IRequest<GameRoomsQueryResult>
    {
        public int GameId { get; init; }
    }
}
