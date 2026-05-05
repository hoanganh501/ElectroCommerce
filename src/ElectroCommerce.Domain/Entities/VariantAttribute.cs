using Domain.Entities;

namespace ElectroCommerce.Domain.Entities
{
    public class VariantAttribute : BaseEntity
    {  
        public string Name { get; set; }
        public ICollection<VariantAttributeValue> AttributeValues { get; set; } = new List<VariantAttributeValue>();
    }
}
