using System.ComponentModel.DataAnnotations;

namespace Krzaq.Mikrus.WebApi.Core.Authorization.DataContracts
{
    public class LogonInput
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string PasswordHash { get; set; } = default!;
    }
}
