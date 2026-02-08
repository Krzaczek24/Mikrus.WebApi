using Krzaq.Mikrus.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.Room
{
    public interface IDbRoomAccess
    {
        ValueTask<RoomDto> CreateRoom();
        ValueTask<IReadOnlyCollection<RoomDto>> GetRoomsList(int gameId);
    }

    internal class DbRoomAccess(AppDbContext context) : IDbRoomAccess
    {
        public async ValueTask<RoomDto> CreateRoom()
        {
            throw new NotImplementedException();
        }

        public async ValueTask<IReadOnlyCollection<RoomDto>> GetRoomsList(int gameId)
        {
            var query = from r in context.Rooms
                        join u in context.Users on r.Owner equals u
                        where r.Game.Id == gameId && r.ExpireDate > DateTime.Now
                        select new RoomDto()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Capacity = r.Capacity,
                            Password = !string.IsNullOrEmpty(r.Password),
                            Owner = new()
                            {
                                DisplayName = u.DisplayName,
                                Login = u.Login,
                            }
                        };
            var rooms = await query.ToListAsync();
            return rooms.AsReadOnly();
        }
    }
}
