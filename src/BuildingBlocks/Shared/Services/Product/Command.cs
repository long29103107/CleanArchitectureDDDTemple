using Contracts.Abstractions.Message;
using static Shared.Dtos.Product.Response;

namespace Shared.Services.Product;

public static class Command
{
    public sealed record CreateProductCommand(string Name, decimal Price) : ICommand<ProductResponse>;
    public sealed record UpdateProductCommand(int Id, string Name,decimal Price) : ICommand<ProductResponse>;
    public sealed record DeleteProductCommand(int Id) : ICommand;
}