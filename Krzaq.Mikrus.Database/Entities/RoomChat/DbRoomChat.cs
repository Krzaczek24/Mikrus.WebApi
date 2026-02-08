using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.RoomChat
{
    internal class DbRoomChat : DbTable
    {
        public virtual int UserId { get; set; }
        public virtual DbUser User { get; set; }
        public virtual int RoomId { get; set; }
        public virtual DbRoom Room { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string Message { get; set; }
    }
}
