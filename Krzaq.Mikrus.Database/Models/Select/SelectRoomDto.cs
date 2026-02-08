namespace Krzaq.Mikrus.Database.Models.Select
{
    public readonly record struct SelectRoomDto(
        int Id,
        int OwnerId,
        string OwnerDisplayName,
        string Name,
        int CurrentPlayers,
        int MaxPlayers,
        bool RequiresPassword);
}
