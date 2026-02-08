using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Create
{
    public class CreateRoomCommand : IRequest<CreateRoomCommandResult>
    {
        public int GameId { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
