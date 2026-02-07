using Krzaq.Mikrus.Database.Models;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandResult
    {
        public required UserDto User { get; init; }
    }
}
