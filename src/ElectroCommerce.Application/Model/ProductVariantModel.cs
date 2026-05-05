namespace ElectroCommerce.Application.Model
{
    public class ProductVariantModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public List<ImageModel> Images { get; set; }
    }
}
