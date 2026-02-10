using Krzaq.Mikrus.Database.Entities.Friend;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.Database.Entities.RoomChat;
using Krzaq.Mikrus.Database.Entities.RoomPlayer;
using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Entities.UserSerssions;
using Krzaq.Mikrus.Database.Entities.UserStats;
using Krzaq.Mikrus.Database.Views.RoomPlayer;

namespace Krzaq.Mikrus.WebApi.Tests.Mocks
{
    internal static class Repo
    {
        // --- Tables ---
        public static IEnumerable<DbFriend> Friends { get; } = [
            
        ];

        public static IEnumerable<DbGame> Games { get; } = [

        ];

        public static IEnumerable<DbRoom> Rooms { get; } = [

        ];

        public static IEnumerable<DbRoomChat> RoomChats { get; } = [

        ];

        public static IEnumerable<DbRoomPlayer> RoomPlayers { get; } = [

        ];

        public static IEnumerable<DbUser> Users { get; } = [

        ];

        public static IEnumerable<DbUserSession> UserSessions { get; } = [

        ];

        public static IEnumerable<DbUserStats> UserStats { get; } = [

        ];

        // --- Views ---
        public static IEnumerable<DbRoomView> RoomsView { get; } = [

        ];
    }
}
