using Krzaq.Mikrus.Database.Base.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Entities.Game
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
