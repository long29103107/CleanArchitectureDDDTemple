﻿using Contracts.Domain;

namespace Product.Domain.Entities;

public sealed class Product : AggregateRoot<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}