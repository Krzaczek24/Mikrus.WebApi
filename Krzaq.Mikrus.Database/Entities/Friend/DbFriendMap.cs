using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.Friend
{
    internal class DbFriendMap : DbTableMap<DbFriend>
    {
        public override void Configure(EntityTypeBuilder<DbFriend> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_f_u_user_id")
                .IsRequired();

            builder.Property(e => e.FriendId)
                .HasColumnName("friend_user_id")
                .IsRequired();

            builder.HasOne(e => e.Friend)
                .WithMany()
                .HasForeignKey(e => e.FriendId)
                .HasConstraintName("FK_f_u_friend_user_id")
                .IsRequired();
        }
    }
}
