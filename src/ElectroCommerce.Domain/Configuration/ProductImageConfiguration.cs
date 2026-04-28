using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.Property(p => p.Url)
                .IsRequired();

            builder.HasOne(p => p.ProductVariant)
                .WithMany(v => v.Images)
                .HasForeignKey(p => p.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.ProductVariantId);
        }
    }
}
