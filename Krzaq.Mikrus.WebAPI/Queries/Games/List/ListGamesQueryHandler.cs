using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games.List
{
    public class ListGamesQueryHandler(IDbGameAccess gameAccess) : IRequestHandler<ListGamesQuery, ListGamesQueryResult>
    {
        public async ValueTask<ListGamesQueryResult> Handle(ListGamesQuery request)
        {
            return new() { Games = await gameAccess.GetGamesList(request.Active) };
        }
    }
}
