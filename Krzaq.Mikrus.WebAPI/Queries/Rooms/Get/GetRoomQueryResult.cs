using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.Get
{
    public class GetRoomQueryResult
    {
        public required SelectRoomDetailsDto Room { get; init; }
    }
}
