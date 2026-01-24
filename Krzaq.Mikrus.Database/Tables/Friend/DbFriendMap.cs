using Krzaq.Mikrus.Database.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Tables.Friend
{
    internal class DbFriendMap : DbTableMap<DbFriend>
    {
        public override void Configure(EntityTypeBuilder<DbFriend> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey("user_id")
                .HasConstraintName("FK_f_u_user_id")
                .IsRequired();

            builder.HasOne(e => e.Friend)
                .WithMany()
                .HasForeignKey("friend_user_id")
                .HasConstraintName("FK_f_u_friend_user_id")
                .IsRequired();
        }
    }
}
