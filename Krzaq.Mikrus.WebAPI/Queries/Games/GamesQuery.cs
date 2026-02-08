using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GamesQuery : IRequest<GamesQueryResult>
    {
        public bool? Active { get; init; }
    }
}
