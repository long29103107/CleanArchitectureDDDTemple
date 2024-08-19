using Contracts.Domains.Interfaces;

namespace Contracts.Domain;

public abstract class EntityAuditBase<T> : BaseEntity<T>, IDateTracking, IUserTracking//,ISoftDeletableTracking
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    //public DateTime? DeletedAt { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    //public string DeletedBy { get; set; }
}