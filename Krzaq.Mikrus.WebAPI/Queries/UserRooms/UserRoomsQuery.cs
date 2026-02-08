using Krzaq.Mikrus.WebApi.Core.Mediators;

namespace Krzaq.Mikrus.WebApi.Queries.UserRooms
{
    public record class UserRoomsQuery : IRequest<UserRoomsQueryResult>
    {
        public int GameId { get; init; }
    }
}
