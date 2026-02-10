using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.GetDetails
{
    public class GetRoomDetailsQueryResult
    {
        public required SelectRoomDetailsDto Room { get; init; }
    }
}
