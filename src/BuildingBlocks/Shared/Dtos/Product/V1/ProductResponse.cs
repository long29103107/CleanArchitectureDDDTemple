namespace Shared.Dtos.Product.V1;

public static class Response
{
    public sealed record ProductResponse(int Id, string Name, decimal Price);
}