using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Krzaq.Mikrus.WebApi.Core.Attributes
{
    public class ProducesResponseAttribute(HttpStatusCode httpStatus)
        : ProducesResponseTypeAttribute((int)httpStatus)
    {

    }

    public class ProducesResponseAttribute<TResponse>(HttpStatusCode httpStatus)
        : ProducesResponseTypeAttribute(typeof(TResponse), (int)httpStatus)
    {

    }
}
