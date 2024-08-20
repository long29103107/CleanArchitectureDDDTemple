using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities = Product.Domain.Entities;

namespace Product.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Entities.Product>
{
    public void Configure(EntityTypeBuilder<Entities.Product> builder)
    {
        builder.HasKey(x => x.Id);
       // builder.Property(x => x.Id).HasConversion<ProductIdConversion>();
    }
}
//public class ProductIdConversion : ValueConverter<ProductId, int>
//{
//    public ProductIdConversion()
//        : base(
//            categoryId => categoryId.Value,
//            value => ProductId.From(value)
//        )
//    { }
//}