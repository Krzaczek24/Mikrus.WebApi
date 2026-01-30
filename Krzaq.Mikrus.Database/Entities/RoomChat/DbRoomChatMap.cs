using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.RoomChat
{
    internal class DbRoomChatMap : DbTableMap<DbRoomChat>
    {
        public override void Configure(EntityTypeBuilder<DbRoomChat> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey("user_id")
                .HasConstraintName("FK_rc_u_user_id")
                .IsRequired();

            builder.HasOne(e => e.Room)
                .WithMany()
                .HasForeignKey("room_id")
                .HasConstraintName("FK_rc_r_room_id")
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .HasColumnName("timestamp")
                .HasDefaultValue()
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.Message)
                .HasColumnName("message")
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
}
