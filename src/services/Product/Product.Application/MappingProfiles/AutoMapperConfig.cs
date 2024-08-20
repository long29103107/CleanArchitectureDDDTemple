using AutoMapper;

namespace Product.Application.MappingProfiles;

public class AutoMapperConfig
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(ProductApplicationReference.Assembly); 
        });

        return config;
    }
}