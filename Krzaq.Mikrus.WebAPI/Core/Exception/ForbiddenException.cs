using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class ForbiddenException(ErrorCode errorCode = ErrorCode.Forbidden, System.Exception? innerException = null)
        : Exceptions.Http.Error.ForbiddenException<ErrorModel>(new(errorCode), innerException)
    {

    }
}
