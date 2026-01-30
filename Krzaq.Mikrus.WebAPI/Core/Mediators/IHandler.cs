namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IHandler
    {
        public ValueTask<object> Handle(object request);
    }

    public interface IHandler<in TRequest, TResponse> : IHandler
        where TRequest : IRequest<TResponse>
    {
        public ValueTask<TResponse> Handle(TRequest request);
        async ValueTask<object> IHandler.Handle(object request) => (await Handle((TRequest)request))!;
    }
}
