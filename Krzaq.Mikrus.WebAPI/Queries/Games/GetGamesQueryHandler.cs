using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GetGamesQueryHandler(
        IDbGameAccess gameAccess)
        : IRequestHandler<GetGamesQuery, IReadOnlyCollection<string>>
    {
        public async ValueTask<IReadOnlyCollection<string>> Handle(GetGamesQuery request)
        {
            return await gameAccess.GetGamesList(request.Active);
        }
    }
}
