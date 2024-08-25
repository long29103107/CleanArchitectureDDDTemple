using Microsoft.AspNetCore.Mvc;

namespace Shared.Dtos.Product.V1;

public sealed record CreateProductRequest(string Name, decimal Price);