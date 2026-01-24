using System.ComponentModel.DataAnnotations;

namespace Krzaq.Mikrus.WebApi.Core.Authorization.DataContracts
{
    public class RegisterInput
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
