using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.Friend
{
    public interface IDbFriendAccess
    {
        //ValueTask<bool> IsFriend(int userId, int friendUserId);
        ValueTask<IReadOnlyCollection<object>> GetFriends(int userId);
    }

    internal class DbFriendAccess(AppDbContext context) : IDbFriendAccess
    {
        public async ValueTask<bool> IsFriend(int userId, int friendUserId)
            => await context.Friends.AnyAsync(f => f.UserId == userId && f.FriendId == friendUserId);

        public async ValueTask<IReadOnlyCollection<object>> GetFriends(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
