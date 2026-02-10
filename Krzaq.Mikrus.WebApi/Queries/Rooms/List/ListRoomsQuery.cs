using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.List
{
    public record class ListRoomsQuery : IRequest<ListRoomsQueryResult>
    {
        public int? GameId { get; init; }
        public bool OnlyJoined { get; init; }
    }
}
