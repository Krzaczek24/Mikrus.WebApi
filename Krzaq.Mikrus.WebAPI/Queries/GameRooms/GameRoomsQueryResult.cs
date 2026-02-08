using Krzaq.Mikrus.Database.Models;

namespace Krzaq.Mikrus.WebApi.Queries.GameRooms
{
    public class GameRoomsQueryResult
    {
        public IReadOnlyCollection<RoomDto> Rooms { get; set; } = [];
    }
}
