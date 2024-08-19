using Microsoft.AspNetCore.Mvc;

namespace Product.Api;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        return Ok();
    }
}