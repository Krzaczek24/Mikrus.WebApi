using Krzaq.Mikrus.WebApi.Shared.Constants;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Krzaq.Mikrus.WebApi.Core.Base
{
    [ApiExplorerSettings(GroupName = ControllerGroup.Api)]
    public abstract class ApiController : ControllerBase
    {
        protected NLog.ILogger Logger { get; }

        public ApiController()
        {
            Logger = LogManager.GetLogger(GetType().UnderlyingSystemType.Name);
        }
    }
}
