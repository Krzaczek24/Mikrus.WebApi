using Krzaq.Mikrus.WebApi.Shared.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ApiRouteAttribute : RouteAttribute
    {
        public ApiRouteAttribute() : base(ControllerGroup.Api)
        {

        }

        public ApiRouteAttribute(string template) : base($"{ControllerGroup.Api}/{template}")
        {

        }
    }
}
