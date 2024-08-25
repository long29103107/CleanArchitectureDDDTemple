using Contracts.Abstractions.Message;
using Shared.Dtos.Product.V1;
using static Shared.Dtos.Product.V1.Response;

namespace Shared.Services.Product.V1;

public static class Command
{
    public sealed record CreateProductCommand(CreateProductRequest Request) : ICommand<ProductResponse>;
    public sealed record UpdateProductCommand(int Id, UpdateProductRequest Request) : ICommand<ProductResponse>;
    public sealed record DeleteProductCommand(int Id) : ICommand;
}