using Krzaq.Mikrus.Database.Base.Tables;

namespace Krzaq.Mikrus.Database.Views.RoomPlayer
{
    public class DbRoomView : DbTable
    {
        public virtual int GameId { get; set; }
        public virtual int OwnerId { get; set; }
        public virtual string OwnerDisplayName { get; set; }
        public virtual string Name { get; set; }
        public virtual int CurrentPlayers { get; set; }
        public virtual int MaxPlayers { get; set; }
        public virtual bool RequiresPassword { get; set; }
        public virtual bool HasGuid { get; set; }
    }
}
