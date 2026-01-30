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

            builder.HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey("owner_id")
                .HasConstraintName("FK_r_u_owner_id")
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany()
                .HasForeignKey("game_id")
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

            builder.Property(e => e.Capacity)
                .HasColumnName("capacity")
                .HasDefaultValue(2)
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

            builder.Property(e => e.FriendsWoPassword)
                .HasColumnName("friends_wo_password")
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
