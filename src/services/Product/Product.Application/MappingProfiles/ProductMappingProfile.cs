using AutoMapper;
using Shared.Dtos.Product;
using Shared.Services.Product;
using Entities = Product.Domain.Entities;

namespace Product.Application.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Response.ProductResponse, Entities.Product>().ReverseMap();
        CreateMap<Command.CreateProductCommand, Entities.Product>().ReverseMap();
        CreateMap<Command.UpdateProductCommand, Entities.Product>().ReverseMap();
    }
}