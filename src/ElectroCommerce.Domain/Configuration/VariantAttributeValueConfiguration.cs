using ElectroCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroCommerce.Domain.Configuration
{
    public class VariantAttributeValueConfiguration : IEntityTypeConfiguration<VariantAttributeValue>
    {
        public void Configure(EntityTypeBuilder<VariantAttributeValue> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasKey(x => x.Id);

            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Value)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => new { x.VariantAttributeId, x.Value })
                   .IsUnique();

            builder.HasOne(x => x.Attribute)
                   .WithMany(x => x.AttributeValues)
                   .HasForeignKey(x => x.VariantAttributeId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
