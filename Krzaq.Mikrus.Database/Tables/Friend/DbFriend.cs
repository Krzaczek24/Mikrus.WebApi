using Krzaq.Mikrus.Database.Core.Tables;
using Krzaq.Mikrus.Database.Tables.User;

namespace Krzaq.Mikrus.Database.Tables.Friend
{
    public class DbFriend : DbTable
    {
        public virtual DbUser User { get; set; }
        public virtual DbUser Friend { get; set; }
    }
}
