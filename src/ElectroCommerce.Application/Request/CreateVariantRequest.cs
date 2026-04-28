
namespace ElectroCommerce.Application.Request
{
    public class CreateVariantRequest
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<VariantAttributeRequest> Attribute { get; set; }
    }
}
