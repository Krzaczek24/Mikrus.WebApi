using Krzaq.Mikrus.Database.Core.Tables;

namespace Krzaq.Mikrus.Database.Tables.Game
{
    public class DbGame : DbTable
    {
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
    }
}
