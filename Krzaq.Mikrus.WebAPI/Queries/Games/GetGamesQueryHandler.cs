using Krzaq.Mikrus.Database;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GetGamesQueryHandler(AppDbContext dbContext) : IHandler<GetGamesQuery, IReadOnlyCollection<string>>
    {
        public async ValueTask<IReadOnlyCollection<string>> Handle(GetGamesQuery request)
        {
            var games = await GetGamesQuery(request)
                .Select(game => game.Name)
                .ToListAsync();
            return games.AsReadOnly();
        }

        private IQueryable<DbGame> GetGamesQuery(GetGamesQuery request) => request.Active switch
        {
            null => dbContext.Games,
            _ => dbContext.Games.Where(g => g.IsActive == request.Active.Value),
        };
    }
}
