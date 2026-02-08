using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.UserRooms
{
    public class UserRoomsQueryHandler : IRequestHandler<UserRoomsQuery, UserRoomsQueryResult>
    {
        public ValueTask<UserRoomsQueryResult> Handle(UserRoomsQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
