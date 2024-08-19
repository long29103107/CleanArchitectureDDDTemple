using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Product;
using System.Reflection;

namespace Product.Api;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        return Ok(await _sender.Send(new Query.GetProductsQuery()));
    }
}