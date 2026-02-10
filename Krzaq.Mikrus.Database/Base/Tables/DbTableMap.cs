using Krzaq.Extensions.String.Notation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krzaq.Mikrus.Database.Base.Tables
{
    internal abstract class DbTableMap<TDbTable> : IEntityTypeConfiguration<TDbTable>
        where TDbTable : DbTable
    {
        protected virtual string TableName { get; } = typeof(TDbTable).Name[2..].ToSnakeCase();

        public virtual void Configure(EntityTypeBuilder<TDbTable> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}
