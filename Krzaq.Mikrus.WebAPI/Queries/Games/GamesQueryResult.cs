using Krzaq.Mikrus.Database.Models;

namespace Krzaq.Mikrus.WebApi.Queries.Games
{
    public class GamesQueryResult
    {
        public IReadOnlyCollection<GameDto> Games { get; set; } = [];
    }
}
