using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Abstractions;
namespace Contracts.Domain;

public class AuditEntity<T> : AggregateRoot, IAuditEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty!;
    public string UpdatedBy { get; set; } = string.Empty!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}