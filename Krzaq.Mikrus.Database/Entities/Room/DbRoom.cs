using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.Room
{
    public class DbRoom : DbTable
    {
        public virtual int OwnerId { get; set; }
        public virtual DbUser Owner { get; set; }
        public virtual int GameId { get; set; }
        public virtual DbGame Game { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int MinPlayers { get; set; }
        public virtual int MaxPlayers { get; set; }
        public virtual string Name { get; set; }
        public virtual string? Password { get; set; }
        public virtual Guid? Guid { get; set; }
        public virtual bool PassFriends { get; set; }
    }
}
