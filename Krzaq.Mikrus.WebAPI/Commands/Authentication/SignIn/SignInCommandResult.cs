namespace Krzaq.Mikrus.WebApi.Commands.Authentication.SignIn
{
    public readonly record struct SignInCommandResult(
        string AccessToken,
        string RefreshToken)
    {

    }
}
