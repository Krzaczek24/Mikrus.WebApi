using Krzaq.Mikrus.WebApi.Core.Mediators;
using System.Text.Json.Serialization;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Join
{
    public record class JoinRoomCommand : IRequest<JoinRoomCommandResult>
    {
        [JsonIgnore]
        public int RoomId { get; init; }
        public Guid? Guid { get; init; }
        public string? Password { get; init; }
    }
}
