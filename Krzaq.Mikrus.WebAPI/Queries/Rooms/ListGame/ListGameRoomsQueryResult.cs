using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.ListGame
{
    public class ListGameRoomsQueryResult
    {
        public IReadOnlyCollection<SelectRoomDto> Rooms { get; init; } = [];
    }
}
