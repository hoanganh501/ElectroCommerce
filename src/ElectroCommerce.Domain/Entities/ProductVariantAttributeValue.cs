using Domain.Entities;

namespace ElectroCommerce.Domain.Entities
{
    public class ProductVariantAttributeValue
    {
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public Guid VariantAttributeValueId { get; set; }
        public VariantAttributeValue VariantAttributeValue { get; set; }
    }
}
