
using Contracts.Domain.Abstractions;

namespace Contracts.Domain;

public class AuditEntity : IAuditEntity
{
    public string CreatedBy { get; set; } = string.Empty!;
    public string UpdatedBy { get; set; } = string.Empty!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}