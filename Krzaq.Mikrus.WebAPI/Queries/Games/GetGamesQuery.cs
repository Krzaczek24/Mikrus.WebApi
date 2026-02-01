using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public readonly record struct GetGamesQuery(
        bool? Active)
        : IRequest<IReadOnlyCollection<string>>;
}
