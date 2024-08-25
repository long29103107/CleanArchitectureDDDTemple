using static Product.Domain.Product.Events.ProductEvents;

namespace Product.Domain.Entities;

public partial class Product
{
    public void Delete() => AddDomainEvent(new DeletedProductEvent(this));
    public void Update() => AddDomainEvent(new UpdatedProductEvent(this));
    public void Create() => AddDomainEvent(new CreatedProductEvent(this));
}

