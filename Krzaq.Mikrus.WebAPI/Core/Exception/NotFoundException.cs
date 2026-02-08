using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class NotFoundException(IEnumerable<ErrorModel> errors, System.Exception? innerException = null)
        : Exceptions.Http.Error.BadRequestException<ErrorModel>(errors, innerException)
    {
        public NotFoundException(ErrorCode errorCode = ErrorCode.NotFound, System.Exception? innerException = null)
            : this([new(errorCode)], innerException)
        {

        }
    }
}
