using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.Room;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.RoomPlayer
{
    public class DbRoomPlayer : DbTable
    {
        public virtual int PlayerId { get; set; }
        public virtual DbUser Player { get; set; }
        public virtual int RoomId { get; set; }
        public virtual DbRoom Room { get; set; }
        public virtual DateTime JoinDate { get; set; }
        public virtual DateTime LastPing { get; set; }
    }
}
