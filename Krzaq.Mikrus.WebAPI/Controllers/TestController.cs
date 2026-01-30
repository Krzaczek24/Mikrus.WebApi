using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.Games;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<JsonResult> TestDb()
        {
            return new JsonResult(await mediator.Send(new GetGamesQuery()));
        }
    }
}
