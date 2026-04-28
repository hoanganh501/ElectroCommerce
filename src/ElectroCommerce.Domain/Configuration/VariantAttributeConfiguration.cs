using ElectroCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroCommerce.Domain.Configuration
{
    internal class VariantAttributeConfiguration: IEntityTypeConfiguration<VariantAttribute>
    {
        public void Configure(EntityTypeBuilder<VariantAttribute> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasOne(p => p.ProductVariant)
                .WithMany(p => p.Attributes)
                .HasForeignKey(p => p.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
