using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GamesQueryHandler(IDbGameAccess gameAccess) : IRequestHandler<GamesQuery, GamesQueryResult>
    {
        public async ValueTask<GamesQueryResult> Handle(GamesQuery request)
        {
            return new() { Games = await gameAccess.GetGamesList(request.Active) };
        }
    }
}
