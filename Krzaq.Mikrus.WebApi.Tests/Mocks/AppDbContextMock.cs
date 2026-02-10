using Krzaq.Mikrus.Database;
using Moq;
using Moq.EntityFrameworkCore;

namespace Krzaq.Mikrus.WebApi.Tests.Mocks
{
    internal class AppDbContextMock : Mock<AppDbContext>
    {
        public AppDbContextMock()
        {
            // --- Tables ---
            Setup(x => x.Friends).ReturnsDbSet(Repo.Friends);
            Setup(x => x.Games).ReturnsDbSet(Repo.Games);
            Setup(x => x.Rooms).ReturnsDbSet(Repo.Rooms);
            Setup(x => x.RoomChats).ReturnsDbSet(Repo.RoomChats);
            Setup(x => x.RoomPlayers).ReturnsDbSet(Repo.RoomPlayers);
            Setup(x => x.Users).ReturnsDbSet(Repo.Users);
            Setup(x => x.UserSessions).ReturnsDbSet(Repo.UserSessions);
            Setup(x => x.UserStats).ReturnsDbSet(Repo.UserStats);

            // --- Views ---
            Setup(x => x.RoomsView).ReturnsDbSet(Repo.RoomsView);
        }
    }
}
