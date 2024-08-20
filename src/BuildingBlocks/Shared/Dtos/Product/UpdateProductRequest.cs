using Microsoft.AspNetCore.Mvc;

namespace Shared.Dtos.Product;

public sealed record UpdateProductRequest( string Name, decimal Price);