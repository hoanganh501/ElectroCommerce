using Application.Interface;
using ElectroCommerce.Application.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class SupplierController : BaseApi
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportSuplierAsyns(ImportSuplierRequest request)
        {
            await _supplierService.ImportSuplierAsyns(request);
            return Ok();
        }
    }
}
