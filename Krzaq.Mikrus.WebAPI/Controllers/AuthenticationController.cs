using Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn;
using Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp;
using Krzaq.Mikrus.WebApi.Core.Controllers;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Mediators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krzaq.Mikrus.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(IMediator mediator) : ApiController
    {
        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task Register([FromBody] SignUpCommand input)
        {
            try
            {
                _ = await UserService.CreateUser(input.Username, input.Username, input.PasswordHash, input.Email, input.FirstName, input.LastName);
            }
            catch (DuplicatedEntryException)
            {
                throw new ConflictException(ErrorCode.UsernameAlreadyTaken);
            }
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async ValueTask<SignInCommandResult> SignIn([FromBody] SignInCommand body) => await mediator.Send(body);

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<AuthenticateOutput> RefreshToken([FromBody] RefreshTokenCommand body)
        {
            if (!TokenBuilder.IsRefreshTokenValid(input.RefreshToken))
                throw new UnauthorizedException(ErrorCode.TokenExpired);

            var user = await UserService.GetUser(input.RefreshToken, HttpContext.GetClientIp());
            if (user == null)
                throw new UnauthorizedException(ErrorCode.TokenInvalid);

            return await GenerateTokens(user, UserService.UpdateRefreshToken);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task Logout() => await Logout(HttpContext.GetClientIp());

        [Authorize]
        [HttpPost("logout-all-machines")]
        public async Task LogoutAllMachines() => await Logout(null);

        private async Task Logout(string? clientIp) => await UserService.RemoveRefreshTokens(User.GetLogin(), clientIp);
    }
}