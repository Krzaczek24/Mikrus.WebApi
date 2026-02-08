using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms
{
    public record class RoomDetailsQuery : IRequest<RoomDetailsQueryResult>
    {
        public int RoomId { get; init; }
    }
}
