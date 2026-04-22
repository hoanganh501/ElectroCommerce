using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasIndex(p => p.ProductId);

            builder.HasMany(v => v.Images)
                .WithOne(i => i.ProductVariant)
                .HasForeignKey(i => i.ProductVariantId);
        }
    }
}
