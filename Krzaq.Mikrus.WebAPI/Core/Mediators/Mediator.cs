using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Exception;

namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IMediator
    {
        public ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }

    internal class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        public static string VALIDATOR_PREFIX = "VALIDATOR";
        public static string HANDLER_PREFIX = "HANDLER";

        public async ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            string requestName = request.GetType().FullName!;

            var validatorInterface = serviceProvider.GetKeyedService<Type>($"{VALIDATOR_PREFIX}_{requestName}");
            if (validatorInterface is not null)
            {
                var validator = (IRequestValidator)serviceProvider.GetRequiredService(validatorInterface);
                var result = validator.Validate(request);
                if (!result.IsValid)
                {
                    var errors = result.Errors.Select(e =>
                    {
                        var errorCode = Enum.Parse<ErrorCode>(e.ErrorCode);
                        return new ErrorModel(errorCode, string.Format(e.ErrorMessage, e.PropertyName.ToCamelCase()));
                    });
                    throw new BadRequestException(errors);
                }
            }

            var handlerInterface = serviceProvider.GetRequiredKeyedService<Type>($"{HANDLER_PREFIX}_{requestName}");
            var handler = (IRequestHandler)serviceProvider.GetRequiredService(handlerInterface);
            return (TResponse)await handler.Handle(request);
        }
    }
}
