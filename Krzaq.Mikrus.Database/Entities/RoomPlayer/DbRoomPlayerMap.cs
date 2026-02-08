using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.RoomPlayer
{
    internal class DbRoomPlayerMap : DbTableMap<DbRoomPlayer>
    {
        public override void Configure(EntityTypeBuilder<DbRoomPlayer> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.PlayerId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.Player)
                .WithMany()
                .HasForeignKey(e => e.PlayerId)
                .HasConstraintName("FK_rp_u_user_id")
                .IsRequired();

            builder.Property(e => e.RoomId)
                .HasColumnName("room_id")
                .IsRequired();

            builder.HasOne(e => e.Room)
                .WithMany()
                .HasForeignKey(e => e.RoomId)
                .HasConstraintName("FK_rp_r_room_id")
                .IsRequired();

            builder.Property(e => e.JoinDate)
                .HasColumnName("join_date")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.LastPing)
                .HasColumnName("last_ping")
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
