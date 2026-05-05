namespace ElectroCommerce.Domain.DTO
{
    public class ProductVariantDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<ImageDto> Images { get; set; }
        public List<AttributeDto> Attributes { get; set; }
    }
}
