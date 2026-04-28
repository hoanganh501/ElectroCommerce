using Api.Controllers;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace ElectroCommerce.Api.Controllers
{
    public class ProductVariantController : BaseApi
    {
        private readonly IProductVariantService _productVariantService;
        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }
    }
}
