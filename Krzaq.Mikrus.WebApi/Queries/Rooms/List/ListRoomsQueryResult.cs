using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.List
{
    public class ListRoomsQueryResult
    {
        public IReadOnlyCollection<SelectRoomDto> Rooms { get; init; } = [];
    }
}
