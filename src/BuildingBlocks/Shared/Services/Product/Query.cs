using DistributedSystem.Contract.Abstractions.Message;
using Microsoft.AspNetCore.Mvc;
using static Shared.Dtos.Product.Response;

namespace Shared.Services.Product;

public static class Query
{
    public sealed record GetListProducQuery() : IQuery<List<ProductResponse>>;
    public sealed record GetProductQuery([FromRoute] int Id) : IQuery<ProductResponse>;
}