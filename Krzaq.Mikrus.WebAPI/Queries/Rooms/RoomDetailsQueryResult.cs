using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms
{
    public class RoomDetailsQueryResult
    {
        public required SelectRoomDetailsDto Room { get; init; }
    }
}
