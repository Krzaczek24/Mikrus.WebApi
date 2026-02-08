using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public class GameRoomsQueryResult
    {
        public IReadOnlyCollection<SelectRoomDto> Rooms { get; init; } = [];
    }
}
