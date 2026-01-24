using Krzaq.Mikrus.Database;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(MikrusDbContext db) : ControllerBase
    {
        [HttpGet]
        public async Task<object> TestDb()
        {
            var game = db.Games.FirstOrDefault();
            return await Task.FromResult(new {
                game?.Name
            });
        }
    }
}
