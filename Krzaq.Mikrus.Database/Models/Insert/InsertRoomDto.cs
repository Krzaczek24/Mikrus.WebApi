namespace Krzaq.Mikrus.Database.Models.Insert
{
    public readonly record struct InsertRoomDto(
        int GameId,
        int OwnerId,
        string Name,
        int MinPlayers,
        int MaxPlayers,
        DateTime ExpireDate,
        string? Password,
        Guid? Guid,
        bool PassFriends);
}
