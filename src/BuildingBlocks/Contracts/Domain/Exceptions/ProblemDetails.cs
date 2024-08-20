using Microsoft.AspNetCore.Mvc;

namespace Contracts.Domain.Exceptions;

public class CustomProblemDetails : ProblemDetails
{
    public IReadOnlyCollection<ValidationError> Errors { get; set; }
}