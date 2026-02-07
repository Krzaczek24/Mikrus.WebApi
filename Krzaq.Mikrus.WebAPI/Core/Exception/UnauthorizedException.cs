using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class UnauthorizedException(ErrorCode errorCode, System.Exception? innerException = null)
        : Exceptions.Http.Error.UnauthorizedException<ErrorModel>(new(errorCode), innerException)
    {

    }
}
