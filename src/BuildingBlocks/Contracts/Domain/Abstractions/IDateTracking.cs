namespace Contracts.Domains.Interfaces;

public interface IDateTracking
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
