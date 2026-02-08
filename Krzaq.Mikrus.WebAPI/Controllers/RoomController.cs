using Krzaq.Mikrus.WebApi.Commands.Rooms.Create;
using Krzaq.Mikrus.WebApi.Commands.Rooms.Join;
using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Authorize]
    [Route("room")]
    public class RoomController(IMediator mediator) : ApiController
    {
        [HttpPost]
        public async ValueTask<CreateRoomCommandResult> CreateRoom([FromBody] CreateRoomCommand command) => await mediator.Send(command);

        [HttpPost("{id}/join")]
        public async ValueTask<JoinRoomCommandResult> JoinRoom([FromRoute] int id, [FromBody] JoinRoomCommand command) => await mediator.Send(command with { RoomId = id });

        [HttpGet("{id}/details")]
        public async ValueTask<RoomDetailsQueryResult> GetDetails([FromRoute] int id) => await mediator.Send(new RoomDetailsQuery { RoomId = id });
    }
}
