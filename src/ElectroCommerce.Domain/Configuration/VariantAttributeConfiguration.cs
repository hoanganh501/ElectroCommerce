using ElectroCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroCommerce.Domain.Configuration
{
    public class VariantAttributeConfiguration: IEntityTypeConfiguration<VariantAttribute>
    {
        public void Configure(EntityTypeBuilder<VariantAttribute> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AttributeValues)
               .WithOne(x => x.Attribute)
               .HasForeignKey(x => x.VariantAttributeId);
        }
    }
}
