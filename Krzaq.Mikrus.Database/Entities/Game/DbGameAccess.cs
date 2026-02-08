using Krzaq.Mikrus.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.Game
{
    public interface IDbGameAccess
    {
        ValueTask<IReadOnlyCollection<GameDto>> GetGamesList(bool? active);
    }

    internal class DbGameAccess(AppDbContext context) : IDbGameAccess
    {
        public async ValueTask<IReadOnlyCollection<GameDto>> GetGamesList(bool? active)
        {
            var games = await GetGamesQuery(active)
                .Select(game => new GameDto
                {
                    Id = game.Id,
                    Name = game.Name,
                })
                .ToListAsync();
            return games.AsReadOnly();
        }

        private IQueryable<DbGame> GetGamesQuery(bool? active) => active switch
        {
            null => context.Games,
            _ => context.Games.Where(g => g.IsActive == active.Value),
        };
    }
}
