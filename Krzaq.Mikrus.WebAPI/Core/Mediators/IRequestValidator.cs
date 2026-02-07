using FluentValidation.Results;

namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IRequestValidator
    {
        ValidationResult Validate(object request);
    }

    public interface IRequestValidator<in TRequest> : IRequestValidator
        where TRequest : IRequest
    {
        ValidationResult Validate(TRequest request);
        ValidationResult IRequestValidator.Validate(object request) => Validate((TRequest)request);
    }
}
