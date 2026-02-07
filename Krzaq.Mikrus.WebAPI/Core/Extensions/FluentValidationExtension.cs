using FluentValidation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using KrzaqTools.Extensions;

namespace Krzaq.Mikrus.WebApi.Core.Extensions
{
    public static class FluentValidationExtension
    {
        public static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> builder, ErrorCode errorCode, string? message = null)
        {
            return builder
                .WithErrorCode(errorCode.ToString())
                .WithMessage(message ?? errorCode.GetDescription());
        }

        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderInitial<T, TProperty> builder, string? message = "{0} is required.")
        {
            return builder
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField, message);
        }

        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilderOptions<T, TProperty> builder, string? message = "{0} is required.")
        {
            return builder
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField, message);
        }
    }
}
