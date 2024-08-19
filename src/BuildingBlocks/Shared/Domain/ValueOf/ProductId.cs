using ValueOf;

namespace Shared.Domain.ValueOf;

public class ProductId : ValueOf<int, ProductId>
{
    protected override void Validate()
    {
        if (Value == 0)
            throw new ArgumentException("Product id can not be null or empty !");
    }
}