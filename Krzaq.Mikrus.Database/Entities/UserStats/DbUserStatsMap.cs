using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.UserStats
{
    internal class DbUserStatsMap : DbTableMap<DbUserStats>
    {
        public override void Configure(EntityTypeBuilder<DbUserStats> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_us_u_user_id")
                .IsRequired();

            builder.Property(e => e.GameId)
                .HasColumnName("game_id")
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .HasConstraintName("FK_us_g_game_id")
                .IsRequired();

            builder.Property(e => e.MatchesCount)
                .HasColumnName("matches_count")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.WinsCount)
                .HasColumnName("wins_count")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(e => e.TotalTimeSpent)
                .HasColumnName("total_time_spent")
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}
