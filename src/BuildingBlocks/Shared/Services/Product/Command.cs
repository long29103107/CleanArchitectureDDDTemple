using Contracts.Abstractions.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Shared.Dtos.Product.Response;

namespace Shared.Services.Product;

public static class Command
{
    public sealed record CreateProductCommand([FromBody] string Name, [FromBody] decimal Price) : ICommand<ProductResponse>;
    public sealed record UpdateProductCommand(int Id, string Name,decimal Price) : ICommand<ProductResponse>;
    //public sealed record UpdatePartialProductCommand(ProductId Id, string Name, decimal Price) : ICommand<ProductResponse>;
    public sealed record DeleteProductCommand([FromRoute] int Id) : ICommand;
}