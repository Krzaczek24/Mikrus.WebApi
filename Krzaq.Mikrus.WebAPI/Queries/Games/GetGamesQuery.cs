using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public record struct GetGamesQuery : IRequest<IReadOnlyCollection<string>>
    {
        public bool? Active { get; set; }
    }
}
