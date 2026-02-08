using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Route("index")]
    public class IndexController : ApiController
    {
        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToJson() => Redirect(Program.ENDPOINT);
    }
}
