using Api.Controllers;
using ElectroCommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ElectroCommerce.Api.Controllers
{
    public class CategoryController : BaseApi
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }
    }
}
