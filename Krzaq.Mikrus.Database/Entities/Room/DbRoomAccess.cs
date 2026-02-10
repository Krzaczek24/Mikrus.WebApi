using Krzaq.Mikrus.Database.Entities.RoomPlayer;
using Krzaq.Mikrus.Database.Models.Insert;
using Krzaq.Mikrus.Database.Models.Select;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.Room
{
    public interface IDbRoomAccess
    {
        ValueTask<bool> IsNameUsed(string name);
        ValueTask<bool> IsGuidUsed(Guid guid);
        ValueTask<bool> IsOwner(int roomId, int userId);
        ValueTask<bool> IsGoodPassword(int roomId, string? password);
        ValueTask<bool> CanEnter(int roomId, int userId);
        ValueTask<bool> CanJoinAsOwnerFriend(int roomId, int userId);
        ValueTask<int> GetFreeSlots(int roomId);
        ValueTask<int> CreateRoom(InsertRoomDto roomParams);
        ValueTask<IReadOnlyCollection<SelectRoomDto>> GetRoomsList(int? gameId);
        ValueTask<IReadOnlyCollection<SelectRoomDto>> GetJoinedRoomsList(int userId, int? gameId);
        ValueTask<SelectRoomDetailsDto> GetRoomDetails(int roomId);
        ValueTask JoinRoom(Guid guid, int userId);
        ValueTask JoinRoom(int roomId, int userId);
        ValueTask LeaveRoom(int roomId, int userId);
        ValueTask DeleteRoom(int roomId);
    }

    internal class DbRoomAccess(AppDbContext context) : IDbRoomAccess
    {
        public async ValueTask<bool> IsNameUsed(string name)
            => await context.Rooms.AnyAsync(r => r.Name == name);
         
        public async ValueTask<bool> IsGuidUsed(Guid guid)
            => await context.Rooms.AnyAsync(r => r.Guid == guid);

        public async ValueTask<bool> IsOwner(int roomId, int userId)
            => await context.Rooms.AnyAsync(r => r.Id == roomId && r.OwnerId == userId);

        public async ValueTask<bool> IsGoodPassword(int roomId, string? password)
            => await context.Rooms.AnyAsync(r => r.Id == roomId && (string.IsNullOrEmpty(r.Password) || r.Password == password));

        public async ValueTask<bool> CanEnter(int roomId, int userId)
            => await context.RoomPlayers.AnyAsync(rp => rp.RoomId == roomId && rp.PlayerId == userId);

        public async ValueTask<bool> CanJoinAsOwnerFriend(int roomId, int userId)
            => await (from r in context.Rooms
                      join f in context.Friends on r.OwnerId equals f.UserId
                      where r.Id == roomId && r.PassFriends && f.FriendId == userId
                      select 1).AnyAsync();

        public async ValueTask<int> GetFreeSlots(int roomId)
            => await context.RoomsView
                .Where(r => r.Id == roomId)
                .Select(r => r.MaxPlayers - r.CurrentPlayers)
                .FirstOrDefaultAsync();

        public async ValueTask<int> CreateRoom(InsertRoomDto roomParams)
        {
            var room = new DbRoom
            {
                GameId = roomParams.GameId,
                OwnerId = roomParams.OwnerId,
                Name = roomParams.Name,
                MinPlayers = roomParams.MinPlayers,
                MaxPlayers = roomParams.MaxPlayers,
                Password = roomParams.Password,
                Guid = roomParams.Guid,
                PassFriends = roomParams.PassFriends,
            };

            await context.Rooms.AddAsync(room);
            await context.SaveChangesAsync();

            return room.Id;
        }

        public async ValueTask<IReadOnlyCollection<SelectRoomDto>> GetRoomsList(int? gameId)
        {
            var query = from r in context.RoomsView
                        where (!gameId.HasValue || r.GameId == gameId) && !r.HasGuid
                        select new SelectRoomDto()
                        {
                            Id = r.Id,
                            OwnerId = r.OwnerId,
                            OwnerDisplayName = r.OwnerDisplayName,
                            Name = r.Name,
                            CurrentPlayers = r.CurrentPlayers,
                            MaxPlayers = r.MaxPlayers,
                            RequiresPassword = r.RequiresPassword,
                        };
            var rooms = await query.ToListAsync();
            return rooms.AsReadOnly();
        }

        public async ValueTask<IReadOnlyCollection<SelectRoomDto>> GetJoinedRoomsList(int userId, int? gameId)
        {
            var query = from r in context.RoomsView
                        join rp in context.RoomPlayers on r.Id equals rp.Room.Id
                        where (!gameId.HasValue || r.GameId == gameId) && rp.PlayerId == userId
                        select new SelectRoomDto()
                        {
                            Id = r.Id,
                            OwnerId = r.OwnerId,
                            OwnerDisplayName = r.OwnerDisplayName,
                            Name = r.Name,
                            CurrentPlayers = r.CurrentPlayers,
                            MaxPlayers = r.MaxPlayers,
                            RequiresPassword = r.RequiresPassword,
                        };
            var rooms = await query.ToListAsync();
            return rooms.AsReadOnly();
        }

        public async ValueTask<SelectRoomDetailsDto> GetRoomDetails(int roomId)
        {
            throw new NotImplementedException();
        }

        public async ValueTask JoinRoom(Guid guid, int userId)
        {
            int roomId = await context.Rooms.Where(r => r.Guid == guid).Select(r => r.Id).FirstOrDefaultAsync();
            if (roomId > 0)
                await JoinRoom(roomId, userId);
        }

        public async ValueTask JoinRoom(int roomId, int userId)
        {
            var now = DateTime.Now;
            var roomPlayer = new DbRoomPlayer
            {
                RoomId = roomId,
                PlayerId = userId,
                JoinDate = now,
                LastPing = now,
            };

            await context.RoomPlayers.AddAsync(roomPlayer);
            await context.SaveChangesAsync();
        }

        public async ValueTask LeaveRoom(int roomId, int userId)
        {
            await context.RoomPlayers
                .Where(rp => rp.RoomId == roomId && rp.PlayerId == userId)
                .ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }

        public async ValueTask DeleteRoom(int roomId)
        {
            await context.Rooms
                .Where(r => r.Id == roomId)
                .ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }
    }
}
