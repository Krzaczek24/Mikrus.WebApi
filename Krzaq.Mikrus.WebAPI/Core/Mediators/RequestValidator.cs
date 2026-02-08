using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using KrzaqTools.Extensions;

namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public abstract class RequestValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
        where TRequest : IRequest
    {
    }

    public static class FluentValidationExtension
    {
        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> builder, ErrorCode errorCode, params IEnumerable<object> @params)
        {
            return builder
                .WithErrorCode(errorCode.ToString())
                .WithMessage(string.Format(errorCode.GetDescription()!, ["{0}", .. @params]));
        }

        public static IRuleBuilderOptions<T, TProperty> WithErrorCodeAndMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> builder, ErrorCode errorCode, string message)
        {
            return builder
                .WithErrorCode(errorCode.ToString())
                .WithMessage(message);
        }
    }
}
