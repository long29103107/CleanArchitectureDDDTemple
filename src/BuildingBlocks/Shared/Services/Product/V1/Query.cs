using DistributedSystem.Contract.Abstractions.Message;
using static Shared.Dtos.Product.V1.Response;

namespace Shared.Services.Product.V1;

public static class Query
{
    public sealed record GetListProducQuery() : IQuery<List<ProductResponse>>;
    public sealed record GetProductQuery(int Id) : IQuery<ProductResponse>;
}