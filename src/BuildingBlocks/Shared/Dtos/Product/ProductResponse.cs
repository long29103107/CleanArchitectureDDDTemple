using Shared.Domain.ValueOf;

namespace Shared.Dtos.Product;

public static class Response
{
    public record ProductResponse(ProductId Id, string Name, decimal Price);
}