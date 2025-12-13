using Krzaq.Mikrus.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        [HttpGet("/")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToJson() => Redirect(Program.ENDPOINT);
    }
}
