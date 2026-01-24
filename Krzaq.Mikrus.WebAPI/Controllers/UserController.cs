using Krzaq.Mikrus.WebApi.Core.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [ApiRoute("user")]
    public class UserController
    {

    }
}
