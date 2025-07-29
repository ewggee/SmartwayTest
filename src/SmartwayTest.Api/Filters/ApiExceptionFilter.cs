using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartwayTest.Domain.Exceptions;

namespace SmartwayTest.Api.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        var ex = context.Exception;

        var statusCode = context.HttpContext.Response.StatusCode = ex switch
        {
            EntityNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var errorResponse = new
        {
            Code = context.HttpContext.Response.StatusCode,
            Error = ex.Message
        };

        context.Result = new JsonResult(errorResponse) { StatusCode = statusCode };

        _logger.LogError("Exception occured: {0}", ex.Message);

        context.ExceptionHandled = true;
    }
}
