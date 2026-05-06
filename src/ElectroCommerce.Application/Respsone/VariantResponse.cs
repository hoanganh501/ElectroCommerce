using ElectroCommerce.Application.Model;

namespace ElectroCommerce.Application.Respsone
{
    public class VariantResponse
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public List<ImageModel> Images { get; set; }
    }
}
