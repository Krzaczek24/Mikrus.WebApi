using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.ListGame
{
    public record class ListGameRoomsQuery : IRequest<ListGameRoomsQueryResult>
    {
        public int GameId { get; init; }
    }
}
