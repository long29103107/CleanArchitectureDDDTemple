using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Shared.APIs;
using Shared.Dtos.Product.V1;
using static Shared.Services.Product.V1.Command;
using static Shared.Services.Product.V1.Query;
namespace Product.Presentation.APIs;

public class ProductApi : ApiEndpoint, ICarterModule
{
    private const string BaseUrl = "/api/v{version:apiVersion}/products";

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group1 = app.NewVersionedApi("Product")
            .MapGroup(BaseUrl)
            .HasApiVersion(1); //.RequireAuthorization();

        group1.MapGet(string.Empty, GetProductsV1);
        group1.MapGet("{id}", GetProductV1);
        group1.MapPost(string.Empty, CreateProductV1);
        group1.MapPut("{id}", UpdateProductV1);
        group1.MapDelete("{id}", DeleteProductV1);
    }

    #region ====== version 1 ======

    public static async Task<IResult> GetProductsV1(ISender sender)
    {
        var result = await sender.Send(new GetListProducQuery());
        return Results.Ok(result);
    }

    public static async Task<IResult> GetProductV1(ISender sender, [FromRoute] int id)
    {
        var result = await sender.Send(new GetProductQuery(id));
        return Results.Ok(result);
    }

    public static async Task<IResult> CreateProductV1(ISender sender, [FromBody] CreateProductRequest request)
    {
        var result = await sender.Send(new CreateProductCommand(request));
        return Results.Ok(result);
    }
    public static async Task<IResult> UpdateProductV1(ISender sender, [FromRoute] int id, [FromBody] UpdateProductRequest request)
    {
        var result = await sender.Send(new UpdateProductCommand(id, request));
        return Results.Ok(result);
    }

    public static async Task<IResult> DeleteProductV1(ISender sender, [FromRoute] int id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));
        return Results.Ok(result);
    }

    #endregion ====== version 1 ======
}