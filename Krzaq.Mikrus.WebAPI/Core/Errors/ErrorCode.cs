using Krzaq.Attributes.EnumToString;
using Krzaq.Extensions.String.Notation;
using KrzaqTools.Extensions;
using System.ComponentModel;

namespace Krzaq.Mikrus.WebApi.Core.Errors
{
    [EnumToString(NameAlterMode.ToUpperSnake)]
    public enum ErrorCode
    {
        [Description("An unknown error occurred")]
        Unknown,

        [Description("Resource is used by some other resource")]
        InUse,
        [Description("Already exists such relation")]
        NonUniqueRelation,

        // --- authorization ---
        [Description("Failed to authorize")]
        Unauthorized,
        [Description("Forbidden")]
        Forbidden,
        [Description("Token expired")]
        TokenExpired,
        [Description("Invalid token")]
        InvalidToken,
        [Description("Token already exists")]
        TokenExists,
        // ---------------------

        // --- request fields ---
        [Description("Field '{0}' is required.")]
        MissingRequestField,
        [Description("Field '{0}' value is not unique.")]
        NonUnique,
        [Description("Field '{0}' value is the identifier of a non-existent resource.")]
        NotFound,
        [Description("Field '{0}' value is not valid SHA512 string.")]
        InvalidSha512,
        [Description("Field '{0}' value cannot be longer than '{1}' characters.")]
        ValueTooLong,
        [Description("Field '{0}' value cannot be non positive.")]
        NonPositiveValue,
        [Description("Field '{0}' value cannot be lesser than '{1}' field value.")]
        LesserThanOtherField,
        [Description("Field '{0}' value cannot be lesser than '{1}'.")]
        LesserThan,
        [Description("Field '{0}' value cannot be greater than '{1}' field value.")]
        GreaterThanOtherField,
        [Description("Field '{0}' value cannot be greater than '{1}'.")]
        GreaterThan,
        [Description("Field '{0}' date cannot be from past.")]
        DateFromPast,
        // -----------------------

        // --- rooms ---
        [Description("User already joined to selected room")]
        AlreadyJoinedToRoom,
        [Description("No free slots in selected room")]
        RoomHasNoFreeSlots,
        // -------------
    }

    public static class ErrorCodeExtension
    {
        public static ErrorModel AsError(this ErrorCode code, params IEnumerable<object> @params)
        {
            string description = code.GetDescription()!;
            string message = string.Format(description, [..@params]);
            return new ErrorModel(code, message);
        }

        public static ErrorModel AsFieldError(this ErrorCode code, string fieldName, params IEnumerable<object> @params)
            => AsError(code, [fieldName.ToCamelCase(), ..@params]);
    }
}
