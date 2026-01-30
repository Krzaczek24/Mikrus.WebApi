using Krzaq.Mikrus.WebApi.Core.Mediators;
using Krzaq.Tools.Reflection;

namespace Krzaq.Mikrus.WebApi.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddTransient<IMediator, Mediator>();
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            foreach (Type handler in ReflectionToolbox.GetAllNonAbstractImplementingInterface(typeof(IHandler)))
            {
                var handlerInterface = handler.GetInterface(typeof(IHandler<,>).Name)
                    ?? throw new NullReferenceException($"No IHandler interface was found for {handler.Name} type");

                string requestName = handlerInterface.GenericTypeArguments[0].FullName!;

                services.AddKeyedSingleton(requestName, handlerInterface);
                services.AddTransient(handlerInterface, handler);
            }

            return services;
        }
    }
}
