using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.WebApi.Core.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Moq;
using System.Security.Claims;

namespace Krzaq.Mikrus.WebApi.Tests.Mocks
{
    internal class IHttpContextAccessorMock : Mock<IHttpContextAccessor>
    {
        private readonly FakeHttpContext httpContext = new();
        public void SetUserId(int value) => httpContext.SetUserId(value);

        public IHttpContextAccessorMock() => Setup(x => x.HttpContext).Returns(() => httpContext);
        public IHttpContextAccessorMock(int userId) : this() => httpContext.SetUserId(userId);
    }

    internal class FakeHttpContext : HttpContext
    {
        private int userId;
        public void SetUserId(int value) => userId = value;

        public override IFeatureCollection Features => throw new NotImplementedException();
        public override HttpRequest Request => throw new NotImplementedException();
        public override HttpResponse Response => throw new NotImplementedException();
        public override ConnectionInfo Connection => throw new NotImplementedException();
        public override WebSocketManager WebSockets => throw new NotImplementedException();

        public override ClaimsPrincipal User { get => new([new([new(UserClaim.Id.ToString().ToCamelCase(), userId.ToString())])]); set => throw new NotImplementedException(); }
        public override IDictionary<object, object?> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override IServiceProvider RequestServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Abort() => throw new NotImplementedException();
    }
}
