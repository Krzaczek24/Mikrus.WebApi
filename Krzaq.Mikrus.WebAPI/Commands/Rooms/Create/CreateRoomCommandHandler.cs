using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Commands.Rooms.Create
{
    public class CreateRoomCommandHandler(IDbRoomAccess roomAccess) : IRequestHandler<CreateRoomCommand, CreateRoomCommandResult>
    {
        public async ValueTask<CreateRoomCommandResult> Handle(CreateRoomCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
