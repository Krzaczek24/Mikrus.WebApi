using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.Games.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Authorize]
    [Route("game")]
    public class GameController(IMediator mediator) : ApiController
    {
        [HttpGet]
        public async ValueTask<ListGamesQueryResult> ListGames() => await mediator.Send(new ListGamesQuery());
    }
}
