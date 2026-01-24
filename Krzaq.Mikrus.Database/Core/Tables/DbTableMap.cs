using Krzaq.Extensions.String.Notation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Core.Tables
{
    internal abstract class DbTableMap<TDbTable> : IEntityTypeConfiguration<TDbTable>
        where TDbTable : DbTable
    {
        public virtual void Configure(EntityTypeBuilder<TDbTable> builder)
        {
            string tableName = typeof(TDbTable).Name[2..].ToSnakeCase();

            builder.ToTable(tableName);

            builder.HasKey("Id");
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}
