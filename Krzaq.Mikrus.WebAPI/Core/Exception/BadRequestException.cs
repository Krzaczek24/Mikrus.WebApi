using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class BadRequestException(IEnumerable<ErrorModel> errors, System.Exception? innerException = null)
        : Exceptions.Http.Error.BadRequestException<ErrorModel>(errors, innerException)
    {
        public BadRequestException(ErrorCode errorCode, System.Exception? innerException = null)
            : this([new(errorCode)], innerException)
        {

        }
    }
}
