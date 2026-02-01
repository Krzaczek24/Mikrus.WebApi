using Krzaq.Mikrus.Database.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.UserSerssions
{
    public interface IDbUserSessionAccess
    {
        ValueTask RemoveRefreshTokens(string login, string? clientIp);
        ValueTask SaveNewRefreshToken(string login, string? clientIp, string refreshToken, DateTime? validUntil);
        ValueTask<bool> UpdateRefreshToken(string login, string? clientIp, string newRefreshToken, DateTime? validUntil);
    }

    internal class DbUserSessionAccess(AppDbContext context) : IDbUserSessionAccess
    {
        public async ValueTask RemoveRefreshTokens(string login, string? clientIp)
        {
            var sessions = await (from us in context.UserSessions
                                  join u in context.Users on us.User.Id equals u.Id
                                  where u.Login == login
                                  select us).ToListAsync();

            if (!string.IsNullOrEmpty(clientIp))
                sessions = [.. sessions.Where(session => session.ClientIp == clientIp)];

            sessions.ForEach(session => context.Remove(session));
            await context.SaveChangesAsync();
        }

        public async ValueTask SaveNewRefreshToken(string login, string? clientIp, string refreshToken, DateTime? validUntil)
        {
            if (await UpdateRefreshToken(login, clientIp, refreshToken, validUntil))
                return;

            var newRefreshToken = new DbUserSession()
            {
                User = await context.Users.FirstAsync(u => u.Login == login),
                RefreshToken = refreshToken,
                ClientIp = clientIp,
                ValidUntil = validUntil
            };

            //try
            //{
            await context.AddAsync(newRefreshToken);
            await context.SaveChangesAsync();
            //}
            //catch (DbUpdateException ex) when (ex.InnerException?.Message.StartsWith("Duplicate entry") ?? false)
            //{
            //    throw new DuplicatedEntryException($"User with login [{login}] already has session on this machine [{clientIp}]", ex);
            //}
        }

        public async ValueTask<bool> UpdateRefreshToken(string login, string? clientIp, string newRefreshToken, DateTime? validUntil)
        {
            var sessions = await (from us in context.UserSessions
                                  join u in context.Users on us.User.Id equals u.Id
                                  where u.Login == login && us.ClientIp == clientIp
                                  select us).ToListAsync();

            foreach (var session in sessions)
            {
                session.ValidUntil = validUntil;
                session.RefreshToken = newRefreshToken;
            }

            return await context.SaveChangesAsync() > 0;
        }
    }
}
