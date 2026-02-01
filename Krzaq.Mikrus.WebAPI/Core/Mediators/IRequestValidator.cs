namespace Krzaq.Mikrus.WebApi.Core.Mediators
{
    public interface IRequestValidator
    {
        ValueTask Validate(object request);
    }

    public interface IRequestValidator<in TRequest> : IRequestValidator
    {
        ValueTask Validate(TRequest request);
        async ValueTask IRequestValidator.Validate(object request) => await Validate((TRequest)request);
    }
}
