using DistributedSystem.Contract.Abstractions.Message;
using static Shared.Dtos.Product.Response;

namespace Shared.Services.Product;

public static class Query
{
    public record GetProductsQuery() : IQuery<List<ProductResponse>>;
    public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
}