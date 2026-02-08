using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.Room
{
    internal class DbRoom : DbTable
    {
        public virtual DbUser Owner { get; set; }
        public virtual DbGame Game { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual int Capacity { get; set; }
        public virtual string Name { get; set; }
        public virtual string? Password { get; set; }
        public virtual Guid? Guid { get; set; }
        public virtual bool FriendsWoPassword { get; set; }
    }
}
