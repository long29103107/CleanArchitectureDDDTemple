namespace Contracts.Domain.Abstractions;

public interface ISoftDeletableTracking
{
    DateTime? DeletedAt { get; set; }
    string DeletedBy { get; set; }
}

