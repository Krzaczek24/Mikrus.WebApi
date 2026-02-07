using Krzaq.Attributes.EnumToString;
using System.ComponentModel;

namespace Krzaq.Mikrus.WebApi.Core.Errors
{
    [EnumToString(NameAlterMode.ToUpperSnake)]
    public enum ErrorCode
    {
        [Description("An unknown error occurred")]
        Unknown,
       
        [Description("Resource has been not found")]
        ResourceNotFound,
        [Description("Already exists resource with that name")]
        NonUniqueName,
        [Description("Resource is used by some other resource")]
        ResourceInUse,
        [Description("Already exists such relation")]
        NonUniqueRelation,

        // --- authorization ---
        [Description("Failed to authorize")]
        Unauthorized,
        [Description("Insufficient permissions")]
        Forbidden,
        [Description("Token expired")]
        TokenExpired,
        [Description("Invalid token")]
        TokenInvalid,
        [Description("Token already exists")]
        TokenExists,
        // ---------------------

        // --- business cases ---
        [Description("Request field is missing")]
        MissingRequestField,

        [Description("Provided login or pasword is invalid")]
        InvalidLoginOrPassword,
        [Description("Selected login is already used")]
        LoginAlreadyInUse,
        // ----------------------
    }
}
