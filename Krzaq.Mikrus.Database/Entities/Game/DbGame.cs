using Krzaq.Mikrus.Database.Base.Tables;

namespace Krzaq.Mikrus.Database.Entities.Game
{
    public class DbGame : DbTable
    {
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
    }
}
