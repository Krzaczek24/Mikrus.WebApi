using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class ConflictException(ErrorCode errorCode, System.Exception? innerException = null)
        : Exceptions.Http.Error.ConflictException<ErrorModel>(new() { Code = errorCode }, innerException)
    {

    }
}
