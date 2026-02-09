using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.Rooms.List
{
    public class ListUserRoomsQueryHandler : IRequestHandler<ListUserRoomsQuery, ListUserRoomsQueryResult>
    {
        public ValueTask<ListUserRoomsQueryResult> Handle(ListUserRoomsQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
