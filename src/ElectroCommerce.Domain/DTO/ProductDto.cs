using Domain.Entities;

namespace ElectroCommerce.Domain.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = false;
        public List<ProductVariantDto> Variants { get; set; }
        public List<SpecificationDto> Specifications { get; set; }
    }
}
