namespace Krzaq.Mikrus.Database.Models.Select
{
    public readonly record struct SelectGameDto(
        int Id,
        string Name,
        int MinPlayers,
        int MaxPlayers);
}
