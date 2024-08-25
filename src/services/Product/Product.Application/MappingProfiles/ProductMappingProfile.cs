using AutoMapper;
using Shared.Dtos.Product.V1;
using Entities = Product.Domain.Entities;

namespace Product.Application.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Response.ProductResponse, Entities.Product>().ReverseMap();
        CreateMap<CreateProductRequest, Entities.Product>().ReverseMap();
        CreateMap<UpdateProductRequest, Entities.Product>().ReverseMap();
    }
}