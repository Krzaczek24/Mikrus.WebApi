using Krzaq.Mikrus.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiController
    {
        [HttpGet("test")]
        public async ValueTask<JsonResult> Test()
        {
            return new JsonResult(new { Text = "Hello world" });
        }
    }
}
