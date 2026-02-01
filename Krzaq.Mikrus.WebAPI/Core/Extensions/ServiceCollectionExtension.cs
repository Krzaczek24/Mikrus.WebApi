using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Tools.Reflection;

namespace Krzaq.Mikrus.WebApi.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
            => services.AddScoped<IMediator, Mediator>();

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            foreach (Type handler in ReflectionToolbox.GetAllNonAbstractImplementingInterface(typeof(IRequestHandler)))
            {
                var handlerInterface = handler.GetInterface(typeof(IRequestHandler<,>).Name)
                    ?? throw new NullReferenceException($"No {nameof(IRequestHandler)} interface was found for {handler.Name} type");

                string requestName = handlerInterface.GenericTypeArguments[0].FullName!;

                services.AddKeyedSingleton(requestName, handlerInterface);
                services.AddTransient(handlerInterface, handler);
            }

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            foreach (Type validator in ReflectionToolbox.GetAllNonAbstractImplementingInterface(typeof(IRequestValidator)))
            {
                var validatorInterface = validator.GetInterface(typeof(IRequestValidator<>).Name)
                    ?? throw new NullReferenceException($"No {nameof(IRequestValidator)} interface was found for {validator.Name} type");

                string requestName = validatorInterface.GenericTypeArguments[0].FullName!;

                services.AddKeyedSingleton(requestName, validatorInterface);
                services.AddTransient(validatorInterface, validator);
            }

            return services;
        }
    }
}
