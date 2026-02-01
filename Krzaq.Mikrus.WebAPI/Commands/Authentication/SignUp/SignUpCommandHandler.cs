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
            var (login, displayName, password) = request;

            if (await userAccess.DoesUserExist(login))
                throw new ConflictException(ErrorCode.LoginAlreadyInUse);

            var user = await userAccess.CreateUser(login, displayName, password);
            return new(user);
        }
    }
}
