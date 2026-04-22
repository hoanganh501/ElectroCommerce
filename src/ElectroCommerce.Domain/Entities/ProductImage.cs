using Domain.Enum;

namespace Domain.Entities
{
    public class ProductImage: BaseEntity
    {
        public string KeyImage { get; set; }
        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public string Metadata { get; set; }
        public ImageType Type { get; set; }
    }
}
