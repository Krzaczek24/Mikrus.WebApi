using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.Room
{
    internal class DbRoomMap : DbTableMap<DbRoom>
    {
        public override void Configure(EntityTypeBuilder<DbRoom> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.OwnerId)
                .HasColumnName("owner_id")
                .IsRequired();

            builder.HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .HasConstraintName("FK_r_u_owner_id")
                .IsRequired();

            builder.Property(e => e.GameId)
                .HasColumnName("game_id")
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey(e => e.GameId)
                .HasConstraintName("FK_r_g_game_id")
                .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .HasDefaultValue()
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.ExpireDate)
                .HasColumnName("expire_date")
                .HasDefaultValue()
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.MinPlayers)
                .HasColumnName("min_players")
                .IsRequired();

            builder.Property(e => e.MaxPlayers)
                .HasColumnName("max_players")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(128);

            builder.Property(e => e.Guid)
                .HasColumnName("guid")
                .HasMaxLength(36);

            builder.Property(e => e.PassFriends)
                .HasColumnName("pass_friends")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
