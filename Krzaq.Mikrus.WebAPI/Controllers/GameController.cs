using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.Games;
using Krzaq.Mikrus.WebApi.Queries.Games.List;
using Krzaq.Mikrus.WebApi.Queries.Rooms.List;
using Krzaq.Mikrus.WebApi.Queries.Rooms.ListGame;
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

        [HttpGet("{id}/rooms")]
        public async ValueTask<ListGameRoomsQueryResult> ListGameRooms([FromRoute] int id) => await mediator.Send(new ListGameRoomsQuery { GameId = id });

        [HttpGet("{id}/joined")]
        public async ValueTask<ListUserRoomsQueryResult> ListUserJoinedRooms([FromRoute] int id) => await mediator.Send(new ListUserRoomsQuery { GameId = id });
    }
}
