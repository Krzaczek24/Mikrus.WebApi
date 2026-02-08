using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public record class GameRoomsQuery : IRequest<GameRoomsQueryResult>
    {
        public int GameId { get; init; }
    }
}
