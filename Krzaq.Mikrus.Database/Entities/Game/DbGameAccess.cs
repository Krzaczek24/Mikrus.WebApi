using Krzaq.Mikrus.Database.Models.Select;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.Database.Entities.Game
{
    public interface IDbGameAccess
    {
        ValueTask<bool> DoesGameExist(int gameId);
        ValueTask<SelectGameDto?> GetGame(int gameId);
        ValueTask<IReadOnlyCollection<SelectGameDto>> GetGamesList(bool? active);
    }

    internal class DbGameAccess(AppDbContext context) : IDbGameAccess
    {
        public async ValueTask<bool> DoesGameExist(int gameId)
            => await context.Games.AnyAsync(g => g.Id == gameId);

        public async ValueTask<SelectGameDto?> GetGame(int gameId)
        {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == gameId);
            if (game is null) return null;
            return new SelectGameDto
            {
                Id = game.Id,
                Name = game.Name,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
            };
        }

        public async ValueTask<IReadOnlyCollection<SelectGameDto>> GetGamesList(bool? active)
        {
            var games = await GetGamesQuery(active)
                .Select(game => new SelectGameDto
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
