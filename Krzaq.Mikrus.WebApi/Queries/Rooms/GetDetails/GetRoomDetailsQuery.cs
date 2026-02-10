using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.GetDetails
{
    public record class GetRoomDetailsQuery : IRequest<GetRoomDetailsQueryResult>
    {
        public int RoomId { get; init; }
    }
}
