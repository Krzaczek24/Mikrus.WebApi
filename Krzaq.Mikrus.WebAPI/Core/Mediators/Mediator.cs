namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IMediator
    {
        public ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }

    internal class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        public async ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            string requestName = request.GetType().FullName!;

            var validatorInterface = serviceProvider.GetKeyedService<Type>(requestName);
            if (validatorInterface is not null)
            {
                var validator = (IRequestValidator)serviceProvider.GetRequiredService(validatorInterface);
                await validator.Validate(request);
            }

            var handlerInterface = serviceProvider.GetRequiredKeyedService<Type>(requestName);
            var handler = (IRequestHandler)serviceProvider.GetRequiredService(handlerInterface);
            return (TResponse)await handler.Handle(request);
        }
    }
}
