using ElectroCommerce.Application.Interface;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Service
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly IProductVariantRepository _productVariantRepository;
        public ProductVariantService(IProductVariantRepository productVariantRepository)
        {
            _productVariantRepository = productVariantRepository;
        }
    }
}
