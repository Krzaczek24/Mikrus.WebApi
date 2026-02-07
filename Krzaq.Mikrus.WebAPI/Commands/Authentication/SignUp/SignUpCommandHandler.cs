using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandHandler(
        IDbUserAccess userAccess)
        : IRequestHandler<SignUpCommand, SignUpCommandResult>
    {
        public async ValueTask<SignUpCommandResult> Handle(SignUpCommand request)
        {
            if (await userAccess.DoesUserExist(request.Login))
                throw new ConflictException(ErrorCode.LoginAlreadyInUse);

            var user = await userAccess.CreateUser(request.Login, request.DisplayName, request.Password);
            return new() { User = user };
        }
    }
}
