using Krzaq.Mikrus.WebApi.Core.Attributes;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Net;

namespace Krzaq.Mikrus.WebApi.Core.Controllers
{
    [ApiController]
    [ProducesResponse(HttpStatusCode.OK)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.BadRequest)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Unauthorized)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Forbidden)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.NotFound)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Conflict)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.InternalServerError)]
    public abstract class ApiController : ControllerBase
    {
        private NLog.ILogger? logger;
        protected NLog.ILogger Logger => logger ??= LogManager.GetLogger(GetType().UnderlyingSystemType.Name);
    }
}
