namespace Shared.Dtos.Product;

public static class Response
{
    public sealed record ProductResponse(int Id, string Name, decimal Price);
}