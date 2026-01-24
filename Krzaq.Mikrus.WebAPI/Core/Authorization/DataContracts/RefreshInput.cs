using System.ComponentModel.DataAnnotations;

namespace Krzaq.Mikrus.WebApi.Core.Authorization.DataContracts
{
    public class RefreshInput
    {
        [Required]
        public string RefreshToken { get; set; } = default!;
    }
}
