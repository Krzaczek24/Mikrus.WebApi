using Krzaq.Mikrus.Database.Models.Insert;
using Krzaq.Mikrus.Database.Models.Select;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.User
{
    public interface IDbUserAccess
    {
        ValueTask<int> CreateUser(InsertUserDto userParams);
        ValueTask UpdateLastLoginDate(string login);
        ValueTask<bool> IsUserDataCorrect(string login, string password);
        ValueTask<bool> DoesUserExist(string login);
        ValueTask<bool> DoesUserExist(int userId);
        ValueTask<SelectUserDto?> GetUser(string login);
        ValueTask<SelectUserDto?> GetUser(string refreshToken, string? clientIp);
    }

    internal class DbUserAccess(AppDbContext context) : IDbUserAccess
    {
        public async ValueTask<int> CreateUser(InsertUserDto userParams)
        {
            var user = new DbUser
            {
                Login = userParams.Login,
                DisplayName = userParams.DisplayName,
                Password = userParams.Password,
            };

            _ = await context.Users.AddAsync(user);
            _ = await context.SaveChangesAsync();

            return user.Id;
        }

        public async ValueTask UpdateLastLoginDate(string login)
            => await context.Users
                .Where(u => u.Login == login)
                .ExecuteUpdateAsync(q => q.SetProperty(p => p.LastLogin, DateTime.Now));

        public async ValueTask<bool> IsUserDataCorrect(string login, string passwordHash)
            => await context.Users.AnyAsync(u => u.Login == login && u.Password == passwordHash);

        public async ValueTask<bool> DoesUserExist(string login)
            => await context.Users.AnyAsync(u => u.Login == login);

        public async ValueTask<bool> DoesUserExist(int userId)
            => await context.Users.AnyAsync(u => u.Id == userId);

        public async ValueTask<SelectUserDto?> GetUser(string login)
        {
            var query = from u in context.Users
                        where u.Login == login
                        select new SelectUserDto
                        {
                            Id = u.Id,
                            Login = u.Login,
                            DisplayName = u.DisplayName,
                            CreateDate = u.CreateDate,
                            LastLogin = u.LastLogin,
                        };
            return await query.SingleOrDefaultAsync();
        }

        public async ValueTask<SelectUserDto?> GetUser(string refreshToken, string? clientIp)
        {
            var query = from u in context.Users
                        join s in context.UserSessions on u.Id equals s.User.Id
                        where s.RefreshToken == refreshToken && s.ClientIp == clientIp && s.ValidUntil > DateTime.Now
                        select new SelectUserDto()
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
