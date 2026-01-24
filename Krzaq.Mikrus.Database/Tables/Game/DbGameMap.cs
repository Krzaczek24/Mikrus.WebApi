using Krzaq.Mikrus.Database.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Tables.Game
{
    internal class DbGameMap : DbTableMap<DbGame>
    {
        public override void Configure(EntityTypeBuilder<DbGame> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(128);
        }
    }
}
