namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IRequest { }
    public interface IRequest<out TResponse> : IRequest { }
}
