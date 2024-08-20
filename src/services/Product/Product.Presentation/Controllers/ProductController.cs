using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Product;
using static Shared.Services.Product.Query;
using static Shared.Services.Product.Command;

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
        return Ok(await _sender.Send(new GetListProducQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        return Ok(await _sender.Send(new GetProductQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductRequest request)
    {
        return Ok(await _sender.Send(new CreateProductCommand(request.Name, request.Price)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateProductRequest request)
    {
        return Ok(await _sender.Send(new UpdateProductCommand(id, request.Name, request.Price)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    { 
        return Ok(await _sender.Send(new DeleteProductCommand(id)));
    }
}