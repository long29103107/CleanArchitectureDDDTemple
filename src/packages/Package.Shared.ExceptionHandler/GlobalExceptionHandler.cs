using Contracts.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace Package.Shared.ExceptionHandler;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger _logger;

    public GlobalExceptionHandler(ILogger logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.Error(exception, exception.Message);

        var statusCode = _GetStatusCode(exception);

        var problemDetails = new CustomProblemDetails
        {
            Status = statusCode,
            Title = GetTitle(exception),
            Detail = exception.Message,
            Errors = GetErrors(exception)
        };
         
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static int _GetStatusCode(Exception exception) =>
    exception switch
    {
        BadRequestException or ValidationException => StatusCodes.Status400BadRequest,
        NotFoundException => StatusCodes.Status404NotFound,
        FormatException => StatusCodes.Status422UnprocessableEntity,
        ServiceUnavailableException => StatusCodes.Status503ServiceUnavailable,
        _ => StatusCodes.Status500InternalServerError
    };

    private static string GetTitle(Exception exception) =>
    exception switch
    {
        DomainException applicationException => applicationException.Title,
        _ => "Server Error"
    };

    private static IReadOnlyCollection<ValidationError> GetErrors(Exception exception)
    {
        IReadOnlyCollection<ValidationError> errors = null;

        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors;
        }

        return errors;
    }
}