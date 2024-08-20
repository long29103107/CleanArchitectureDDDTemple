namespace Contracts.Domain.Exceptions;
public abstract class ServiceUnavailableException : DomainException
{
    protected ServiceUnavailableException(string message)
        : base("Service Unavailable", message)
    {
    }
}