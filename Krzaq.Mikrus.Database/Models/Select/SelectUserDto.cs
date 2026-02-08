namespace Krzaq.Mikrus.Database.Models.Select
{
    public readonly record struct SelectUserDto(
        int Id,
        string Login,
        string? DisplayName,
        DateTime CreateDate,
        DateTime? LastLogin);
}
