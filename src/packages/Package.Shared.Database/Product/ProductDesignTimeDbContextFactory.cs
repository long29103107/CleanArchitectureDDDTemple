using Product.Persistence;

namespace MyBlog.Shared.Databases.Category;

public class ProductDesignTimeDbContextFactory : DesignTimeDbContextFactory<ProductDbContext>
{
    protected override string _dbConnStrKey { get; set; } = "Product";
}