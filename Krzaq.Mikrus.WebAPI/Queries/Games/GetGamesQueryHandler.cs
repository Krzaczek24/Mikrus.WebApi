using Krzaq.Mikrus.Database;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Microsoft.EntityFrameworkCore;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GetGamesQueryHandler(MikrusDbContext dbContext) : IHandler<GetGamesQuery, IReadOnlyCollection<string>>
    {
        public async ValueTask<IReadOnlyCollection<string>> Handle(GetGamesQuery request)
        {
            var games = await dbContext.Games.Select(game => game.Name).ToListAsync();
            return games.AsReadOnly();
        }
    }
}
