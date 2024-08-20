﻿using Contracts.Domain.Exceptions;

namespace Product.Domain.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(int productId)
        : base($"The product with the id {productId} was not found.") { }
}