using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.Get
{
    public record class GetRoomQuery : IRequest<GetRoomQueryResult>
    {
        public int RoomId { get; init; }
    }
}
