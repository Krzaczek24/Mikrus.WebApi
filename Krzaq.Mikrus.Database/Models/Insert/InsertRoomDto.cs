namespace Krzaq.Mikrus.Database.Models.Insert
{
    public readonly record struct InsertRoomDto(
        int GameId,
        int OwnerId,
        string Name,
        int MinPlayers,
        int MaxPlayers,
        string? Password,
        Guid? Guid,
        bool PassFriends);
}
