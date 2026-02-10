using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Views.RoomPlayer
{
    internal class DbRoomViewMap : DbTableMap<DbRoomView>
    {
        public override void Configure(EntityTypeBuilder<DbRoomView> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.GameId)
                .HasColumnName("game_id")
                .IsRequired();

            builder.Property(e => e.OwnerId)
                .HasColumnName("owner_id")
                .IsRequired();

            builder.Property(e => e.OwnerDisplayName)
                .HasColumnName("owner_display_name")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(e => e.CurrentPlayers)
                .HasColumnName("current_players")
                .IsRequired();

            builder.Property(e => e.MaxPlayers)
                .HasColumnName("max_players")
                .IsRequired();

            builder.Property(e => e.RequiresPassword)
                .HasColumnName("requires_password")
                .IsRequired();

            builder.Property(e => e.HasGuid)
                .HasColumnName("has_guid")
                .IsRequired();
        }
    }
}
