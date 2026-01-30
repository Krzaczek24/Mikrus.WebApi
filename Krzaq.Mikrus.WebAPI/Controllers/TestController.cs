using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Mikrus.WebApi.Queries.Games;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(IMediator mediator) : ApiController
    {
        [HttpGet]
        public async ValueTask<JsonResult> TestDb()
        {
            return new JsonResult(await mediator.Send(new GetGamesQuery()));
        }
    }
}
