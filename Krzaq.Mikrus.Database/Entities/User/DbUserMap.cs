using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.User
{
    internal class DbUserMap : DbTableMap<DbUser>
    {
        public override void Configure(EntityTypeBuilder<DbUser> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Login)
                .HasColumnName("login")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.DisplayName)
                .HasColumnName("display_name")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(e => e.CreateDate)
                .HasColumnName("create_date")
                .HasDefaultValue()
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(e => e.LastLogin)
                .HasColumnName("last_login");
        }
    }
}
