using Domain.Enum;

namespace Domain.Entities
{
    public class ProductImage: BaseEntity
    {
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public ImageType Type { get; set; }
    }
}
