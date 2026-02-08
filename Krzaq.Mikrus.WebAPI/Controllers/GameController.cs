using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.GameRooms;
using Krzaq.Mikrus.WebApi.Queries.Games;
using Krzaq.Mikrus.WebApi.Queries.UserRooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Authorize]
    [Route("game")]
    public class GameController(IMediator mediator) : ApiController
    {
        [HttpGet]
        public async ValueTask<GamesQueryResult> ListGames() => await mediator.Send(new GamesQuery());

        [HttpGet("{id}/rooms")]
        public async ValueTask<GameRoomsQueryResult> ListGameRooms([FromRoute] int id) => await mediator.Send(new GameRoomsQuery { GameId = id });

        [HttpGet("{id}/joined")]
        public async ValueTask<UserRoomsQueryResult> ListUserJoinedRooms([FromRoute] int id) => await mediator.Send(new UserRoomsQuery { GameId = id });
    }
}
