using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games.List
{
    public class ListGamesQuery : IRequest<ListGamesQueryResult>
    {
        public bool? Active { get; init; }
    }
}
