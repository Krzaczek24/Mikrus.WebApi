using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.UserSerssions
{
    public class DbUserSession : DbTable
    {
        public virtual int UserId { get; set; }
        public virtual DbUser User { get; set; }
        public virtual string RefreshToken { get; set; }
        public virtual string ClientIp { get; set; }
        public virtual DateTime? ValidUntil { get; set; }
    }
}
