using Krzaq.Mikrus.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.User
{
    public interface IDbUserAccess
    {
        ValueTask<UserDto> CreateUser(string login, string? displayName, string password);
        ValueTask UpdateLastLoginDate(string login);
        ValueTask<bool> IsUserDataCorrect(string login, string password);
        ValueTask<bool> DoesUserExist(string login);
        ValueTask<UserDto?> GetUser(string login);
        ValueTask<UserDto?> GetUser(string refreshToken, string? clientIp);
    }

    internal class DbUserAccess(AppDbContext context) : IDbUserAccess
    {
        public async ValueTask<UserDto> CreateUser(string login, string? displayName, string password)
        {
            var user = new DbUser
            {
                Login = login,
                DisplayName = displayName,
                Password = password,
            };

            _ = await context.Users.AddAsync(user);
            _ = await context.SaveChangesAsync();

            return new()
            {
                Id = user.Id,
                Login = login,
                DisplayName = displayName,
                CreateDate = user.CreateDate,
                LastLogin = user.LastLogin,
            };
        }

        public async ValueTask UpdateLastLoginDate(string login)
            => await context.Users
                .Where(u => u.Login == login)
                .ExecuteUpdateAsync(q => q.SetProperty(p => p.LastLogin, DateTime.Now));

        public async ValueTask<bool> IsUserDataCorrect(string login, string passwordHash)
            => await context.Users.AnyAsync(u => u.Login == login && u.Password == passwordHash);

        public async ValueTask<bool> DoesUserExist(string login)
            => await context.Users.AnyAsync(user => user.Login == login);

        public async ValueTask<UserDto?> GetUser(string login)
        {
            var query = from u in context.Users
                        where u.Login == login
                        select new UserDto()
                        {
                            Id = u.Id,
                            Login = u.Login,
                            DisplayName = u.DisplayName,
                            CreateDate = u.CreateDate,
                            LastLogin = u.LastLogin,
                        };
            return await query.SingleOrDefaultAsync();
        }

        public async ValueTask<UserDto?> GetUser(string refreshToken, string? clientIp)
        {
            var query = from u in context.Users
                        join s in context.UserSessions on u.Id equals s.User.Id
                        where s.RefreshToken == refreshToken && s.ClientIp == clientIp && s.ValidUntil > DateTime.Now
                        select new UserDto()
                        {
                            Id = u.Id,
                            Login = u.Login,
                            DisplayName = u.DisplayName,
                            CreateDate = u.CreateDate,
                            LastLogin = u.LastLogin,
                        };
            return await query.SingleOrDefaultAsync();
        }
    }
}
