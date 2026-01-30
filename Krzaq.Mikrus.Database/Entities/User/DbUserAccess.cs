using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.User
{
    public interface IDbUserAccess
    {
        ValueTask UpdateLastLoginDate(string login);
        ValueTask RemoveRefreshTokens(string login, string? clientIp);
        ValueTask SaveNewRefreshToken(string login, string? clientIp, string refreshToken, DateTime? validUntil);
        ValueTask<bool> UpdateRefreshToken(string login, string? clientIp, string newRefreshToken, DateTime? validUntil);
        ValueTask<bool> AuthenticateUser(string login, string passwordHash);
        ValueTask<bool> DoesUserExist(int id);
        ValueTask<DbUser?> GetUser(int id);
        ValueTask<DbUser?> GetUser(string login);
        ValueTask<DbUser?> GetUser(string refreshToken, string? clientIp);
        ValueTask CreateUser(string login, string? displayName, string passwordHash);
    }

    internal class DbUserAccess(AppDbContext context) : IDbUserAccess
    {
        public async ValueTask UpdateLastLoginDate(string login)
            => await context.Users
                .Where(u => u.Login == login)
                .ExecuteUpdateAsync(q => q.SetProperty(p => p.LastLogin, DateTime.Now));

        public async ValueTask RemoveRefreshTokens(string login, string? clientIp)
        {

        }

        public async ValueTask SaveNewRefreshToken(string login, string? clientIp, string refreshToken, DateTime? validUntil)
        {

        }

        public async ValueTask<bool> UpdateRefreshToken(string login, string? clientIp, string newRefreshToken, DateTime? validUntil)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> AuthenticateUser(string login, string passwordHash)
            => await context.Users
                .Where(u => u.Login == login && u.Password == passwordHash)
                .AnyAsync();

        public async ValueTask<bool> DoesUserExist(int id)
            => await context.Users.AnyAsync(user => user.Id == id);

        public async ValueTask<DbUser?> GetUser(int id)
            => await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async ValueTask<DbUser?> GetUser(string login)
            => context.Users.FirstOrDefault(x => x.Login == login);

        public async ValueTask<DbUser?> GetUser(string refreshToken, string? clientIp)
        {
            throw new NotImplementedException();
        }

        public async ValueTask CreateUser(string login, string? displayName, string password)
        {
            var user = new DbUser
            {
                Login = login,
                DisplayName = displayName,
                Password = password,
            };

            _ = await context.Users.AddAsync(user);
            _ = await context.SaveChangesAsync();
        }
    }
}
