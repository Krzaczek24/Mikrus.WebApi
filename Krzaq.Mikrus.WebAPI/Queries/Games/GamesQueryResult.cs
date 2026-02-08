using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GamesQueryResult
    {
        public IReadOnlyCollection<SelectGameDto> Games { get; init; } = [];
    }
}
