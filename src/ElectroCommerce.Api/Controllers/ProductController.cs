using Api.Controllers;
using Application.Interface;
using Domain.Entities;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ElectroCommerce.Api.Controllers
{
    public class ProductController : BaseApi
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
        {
            return Ok(await _productService.CreateProductAsync(request));
        }

        [HttpPost("GetDetail")]
        public async Task<IActionResult> GetProductDetailAsync(Guid id, ProductDetailRequest? request)
        {
            return Ok(await _productService.GetProductDetailAsync(id, request));
        }

        [HttpPost("SearchWithPagination")]
        public async Task<IActionResult> SearchWithPaginationAsync(SearchProductRequest request)
        {
            return Ok(await _productService.SearchWithPaginationAsync(request));
        }
    }
}
