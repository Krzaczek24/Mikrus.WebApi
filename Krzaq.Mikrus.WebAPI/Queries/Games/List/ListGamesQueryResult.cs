using Krzaq.Mikrus.Database.Models.Select;

namespace Krzaq.Mikrus.WebApi.Queries.Games.List
{
    public class ListGamesQueryResult
    {
        public IReadOnlyCollection<SelectGameDto> Games { get; init; } = [];
    }
}
