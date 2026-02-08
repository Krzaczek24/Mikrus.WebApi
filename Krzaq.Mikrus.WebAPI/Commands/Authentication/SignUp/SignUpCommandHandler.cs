using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Models.Insert;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignUp
{
    public class SignUpCommandHandler(IDbUserAccess userAccess)
        : IRequestHandler<SignUpCommand, SignUpCommandResult>
    {
        public async ValueTask<SignUpCommandResult> Handle(SignUpCommand request)
        {
            if (await userAccess.DoesUserExist(request.Login))
                throw new ConflictException(ErrorCode.NonUnique);

            var userParams = new InsertUserDto
            {
                Login = request.Login,
                DisplayName = request.DisplayName ?? request.Login,
                Password = request.Password,
            };

            int userId = await userAccess.CreateUser(userParams);
            return new SignUpCommandResult { UserId = userId };
        }
    }
}
