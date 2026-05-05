using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [AllowAnonymous]
    public abstract class BaseApi : Controller
    {
        protected Guid GetCurrentUser()
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User?.FindFirst("sub")?.Value;

            if (Guid.TryParse(userId, out var guid))
                return guid;

            throw new UnauthorizedAccessException("Invalid user id in token");
        }
    }
}
