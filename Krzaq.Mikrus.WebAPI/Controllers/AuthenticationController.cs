using Krzaq.Mikrus.WebApi.Commands.Authentication.Logout;
using Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken;
using Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn;
using Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp;
using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [Route("auth")]
    public class AuthenticationController(IMediator mediator) : ApiController
    {
        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async ValueTask<SignUpCommandResult> SignUp([FromBody] SignUpCommand command) => await mediator.Send(command);

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async ValueTask<SignInCommandResult> SignIn([FromBody] SignInCommand command) => await mediator.Send(command);

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async ValueTask<RefreshTokenCommandResult> RefreshToken([FromBody] RefreshTokenCommand command) => await mediator.Send(command);

        [Authorize]
        [HttpPost("logout")]
        public async ValueTask Logout() => await mediator.Send(new LogoutCommand { AllMachines = false });

        [Authorize]
        [HttpPost("logout-all-machines")]
        public async ValueTask LogoutAllMachines() => await mediator.Send(new LogoutCommand { AllMachines = true });
    }
}