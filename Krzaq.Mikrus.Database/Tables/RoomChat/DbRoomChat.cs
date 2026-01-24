using Krzaq.Mikrus.Database.Core.Tables;
using Krzaq.Mikrus.Database.Tables.Room;
using Krzaq.Mikrus.Database.Tables.User;

namespace Krzaq.Mikrus.Database.Tables.RoomChat
{
    public class DbRoomChat : DbTable
    {
        public virtual DbUser User { get; set; }
        public virtual DbRoom Room { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string Message { get; set; }
    }
}
