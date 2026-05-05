using ElectroCommerce.Application.Model;

namespace ElectroCommerce.Application.Request
{
    public class ProductDetailRequest
    {
        public List<AttributeModel> Filters { get; set; }
    }
}
