using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.Friend
{
    internal class DbFriend : DbTable
    {
        public virtual DbUser User { get; set; }
        public virtual DbUser Friend { get; set; }
    }
}
