using Domain.Entities;
using ElectroCommerce.Application.Request;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Validators
{
    public class ProductValidator
    {
        private readonly IProductRepository _productRepository;

        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
