using Krzaq.Mikrus.Database.Core.Tables;
using Krzaq.Mikrus.Database.Tables.Game;
using Krzaq.Mikrus.Database.Tables.User;

namespace Krzaq.Mikrus.Database.Tables.UserStats
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
