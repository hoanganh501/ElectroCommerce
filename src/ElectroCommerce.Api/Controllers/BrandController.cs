using Api.Controllers;
using ElectroCommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ElectroCommerce.Api.Controllers
{
    public class BrandController : BaseApi
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _brandService.GetAllAsync());
        }
    }
}
