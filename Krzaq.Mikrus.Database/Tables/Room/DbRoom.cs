using Krzaq.Mikrus.Database.Core.Tables;
using Krzaq.Mikrus.Database.Tables.Game;
using Krzaq.Mikrus.Database.Tables.User;

namespace Krzaq.Mikrus.Database.Tables.Room
{
    public class DbRoom : DbTable
    {
        public virtual DbUser Owner { get; set; }
        public virtual DbGame Game { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public int Capacity { get; set; }
        public virtual string Name { get; set; }
        public virtual string? Password { get; set; }
        public virtual Guid? Guid { get; set; }
        public virtual bool FriendsWoPassword { get; set; }
    }
}
