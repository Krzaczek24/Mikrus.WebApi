using Krzaq.Converters.EnumToString;
using System.Text.Json.Serialization;

namespace Krzaq.Mikrus.WebApi.Core.Errors
{
    public class ErrorModel : Krzaq.Errors.Model.ErrorModel<ErrorCode>
    {
        [JsonConverter(typeof(EnumToStringConverter<ErrorCode>))]
        public override ErrorCode Code { get; set; }
    }
}
