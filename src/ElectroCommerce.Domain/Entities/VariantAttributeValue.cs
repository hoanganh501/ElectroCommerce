using Domain.Entities;

namespace ElectroCommerce.Domain.Entities
{
    public class VariantAttributeValue : BaseEntity
    {
        public Guid VariantAttributeId { get; set; }
        public VariantAttribute Attribute { get; set; }
        public string Value { get; set; } 
        public ICollection<ProductVariantAttributeValue> ProductVariantAttributeValues { get; set; }
    }
}
