namespace Krzaq.Mikrus.Database.Models
{
    public readonly record struct UserDto(
        int Id,
        string Login,
        string DisplayName,
        DateTime CreateDate,
        DateTime? LastLogin);
}
