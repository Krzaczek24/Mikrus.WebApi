using Krzaq.Mikrus.WebApi.Core.Errors;

namespace Krzaq.Mikrus.WebApi.Core.Exception
{
    public class ConflictException(IEnumerable<ErrorModel> errors, System.Exception? innerException = null)
        : Exceptions.Http.Error.ConflictException<ErrorModel>(errors, innerException)
    {
        public ConflictException(ErrorCode errorCode, System.Exception? innerException = null)
            : this([new(errorCode)], innerException)
        {

        }
    }
}
