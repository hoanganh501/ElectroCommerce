using Microsoft.AspNetCore.Http;

namespace ElectroCommerce.Application.Request
{
    public class ImportSuplierRequest
    {
        public IFormFile File { get; set; }
    }
}
