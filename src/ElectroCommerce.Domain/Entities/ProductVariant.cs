using ElectroCommerce.Domain.Entities;

namespace Domain.Entities
{
    public class ProductVariant: BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<VariantAttribute> Attributes { get; set; } = new List<VariantAttribute>();
        public ICollection<ProductImage> Images { get; set; }
    }
}
