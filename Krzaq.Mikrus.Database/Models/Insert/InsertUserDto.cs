namespace Krzaq.Mikrus.Database.Models.Insert
{
    public readonly record struct InsertUserDto(
        string Login,
        string DisplayName,
        string Password);
}
