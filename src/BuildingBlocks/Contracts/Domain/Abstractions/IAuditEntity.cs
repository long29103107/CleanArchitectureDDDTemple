using Contracts.Domains.Interfaces;

namespace Contracts.Domain.Abstractions;

public interface IAuditEntity : IDateTracking, IUserTracking
{

}