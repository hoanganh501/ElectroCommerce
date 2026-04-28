using Domain.Entities;

namespace ElectroCommerce.Domain.Entities
{
    public class VariantAttribute : BaseEntity
    {
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
