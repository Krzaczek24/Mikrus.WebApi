using FluentValidation;

namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public abstract class RequestValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
        where TRequest : IRequest
    {
    }
}
