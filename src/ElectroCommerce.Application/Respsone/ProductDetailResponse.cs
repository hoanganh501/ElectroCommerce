using ElectroCommerce.Application.Model;

namespace ElectroCommerce.Application.Respsone
{
    public class ProductDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = false;
        public List<ProductVariantModel> Variants { get; set; }
        public List<SpecificationModel> Specifications { get; set; }
    }
}
