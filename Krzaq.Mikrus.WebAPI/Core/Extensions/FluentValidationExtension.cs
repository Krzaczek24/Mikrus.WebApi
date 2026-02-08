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

        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> builder, string? message = "Field '{0}' is required.")
        {
            return builder
                .NotNull()
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingRequestField, message);
        }

        public static IRuleBuilderOptions<T, string> Sha512<T>(this IRuleBuilderOptions<T, string> builder, string? message = "Field '{0}' value is not valid SHA512 string.")
        {
            return builder
                .Matches(@"[a-fA-F0-9]{128}")
                .WithErrorCode(ErrorCode.InvalidSha512Value, message);
        }
    }
}
