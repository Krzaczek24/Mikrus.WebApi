using Krzaq.Mikrus.WebApi.Core.Attributes;
using Krzaq.Mikrus.WebApi.Core.Errors;
using System.Net;

namespace Krzaq.Mikrus.WebApi.Core.Base
{
    [ProducesResponse(HttpStatusCode.OK)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.BadRequest)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Unauthorized)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Forbidden)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.NotFound)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.Conflict)]
    [ProducesResponse<ErrorResponse>(HttpStatusCode.InternalServerError)]
    public abstract class ResponseController
    {

    }
}
