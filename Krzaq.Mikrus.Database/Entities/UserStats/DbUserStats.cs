using Krzaq.Mikrus.Database.Base.Tables;
using Krzaq.Mikrus.Database.Entities.Game;
using Krzaq.Mikrus.Database.Entities.User;

namespace Krzaq.Mikrus.Database.Entities.UserStats
{
    public class DbUserStats : DbTable
    {
        public virtual DbUser User { get; set; }
        public virtual DbGame Game { get; set; }
        public virtual int MatchesCount { get; set; }
        public virtual int WinsCount { get; set; }
        public virtual int TotalTimeSpent { get; set; }
    }
}
