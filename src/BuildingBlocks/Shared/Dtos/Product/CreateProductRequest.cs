using Microsoft.AspNetCore.Mvc;

namespace Shared.Dtos.Product;

public sealed record CreateProductRequest(string Name, decimal Price);