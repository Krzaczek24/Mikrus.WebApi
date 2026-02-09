using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.List
{
    public record class ListUserRoomsQuery : IRequest<ListUserRoomsQueryResult>
    {
        public int GameId { get; init; }
    }
}
