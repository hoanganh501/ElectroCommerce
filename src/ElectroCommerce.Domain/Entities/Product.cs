namespace Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsAvailable { get; set; } = false;
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductSpecification> Specifications { get; set; } = new List<ProductSpecification>();
    }
}
