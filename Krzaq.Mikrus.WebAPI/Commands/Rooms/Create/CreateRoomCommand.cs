using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Create
{
    public record class CreateRoomCommand : IRequest<CreateRoomCommandResult>
    {
        public int GameId { get; init; }
        public string Name { get; init; } = string.Empty;
        public int MinPlayers { get; init; }
        public int MaxPlayers { get; init; }
        public DateTime ExpireDate { get; init; }
        public string? Password { get; init; }
        public Guid? Guid { get; init; }
        public bool PassFriends { get; init; }
    }
}
