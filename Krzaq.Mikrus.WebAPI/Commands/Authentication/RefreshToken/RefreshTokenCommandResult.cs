namespace Krzaq.Mikrus.WebApi.Commands.Authentication.RefreshToken
{
    public readonly record struct RefreshTokenCommandResult(string AccessToken, string RefreshToken);
}
