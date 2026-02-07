namespace Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken
{
    public class RefreshTokenCommandResult
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken { get; init; }
    }
}
