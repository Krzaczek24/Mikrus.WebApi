using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.UserSerssions
{
    internal class DbUserSessionMap : DbTableMap<DbUserSession>
    {
        public override void Configure(EntityTypeBuilder<DbUserSession> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.RefreshToken)
                .HasColumnName("refresh_token")
                .IsRequired()
                .HasMaxLength(1024);

            builder.Property(e => e.ClientIp)
                .HasColumnName("client_ip")
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.ValidUntil)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(3);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey("user_id")
                .HasConstraintName("FK_us2_u_user_id")
                .IsRequired();
        }
    }
}
