using ElectroCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroCommerce.Domain.Configuration
{
    public class ProductVariantAttributeValueConfiguration : IEntityTypeConfiguration<ProductVariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductVariantAttributeValue> builder)
        {
            builder.HasKey(x => new { x.ProductVariantId, x.VariantAttributeValueId });

            builder.HasOne(x => x.ProductVariant)
                   .WithMany(x => x.ProductVariantAttributeValues)
                   .HasForeignKey(x => x.ProductVariantId);

            builder.HasOne(x     => x.VariantAttributeValue)
                   .WithMany(x => x.ProductVariantAttributeValues)
                   .HasForeignKey(x => x.VariantAttributeValueId);

            builder.HasIndex(x => x.VariantAttributeValueId);
        }
    }
}
