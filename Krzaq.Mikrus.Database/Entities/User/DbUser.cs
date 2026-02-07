using Krzaq.Mikrus.Database.Base.Tables;

namespace Krzaq.Mikrus.Database.Entities.User
{
    internal class DbUser : DbTable
    {
        public virtual string Login { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? LastLogin { get; set; }
    }
}
