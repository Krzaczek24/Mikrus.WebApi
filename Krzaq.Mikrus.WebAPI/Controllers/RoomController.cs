using Krzaq.Mikrus.WebApi.Commands.Rooms.Create;
using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
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

        [HttpGet("{id}/details")]
        public async ValueTask<RoomDetailsQueryResult> GetDetails([FromRoute] int id) => await mediator.Send(new RoomDetailsQuery() { RoomId = id });
    }
}
