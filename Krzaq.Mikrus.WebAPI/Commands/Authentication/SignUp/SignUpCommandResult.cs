using Krzaq.Mikrus.Database.Models;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public readonly record struct SignUpCommandResult(UserDto User);
}
