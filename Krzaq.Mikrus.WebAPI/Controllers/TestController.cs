using Krzaq.Mikrus.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public Task<Test> GetTestObject()
        {
            var result = new Test
            {
                Key = 2137,
                Value = "Tak było. Nie zmyślam."
            };
            return Task.FromResult(result);
        }

        [HttpGet("config")]
        public Task<JsonResult> GetConfig([FromServices] IDbConnectionStringProvider provider)
        {
            var result = new JsonResult(new
            {
                connectionString = provider.GetConnectionString()
            });

            return Task.FromResult(result);
        }

        public class Test
        {
            public required int Key { get; set; }
            public required string Value { get; set; }
        }
    }
}
