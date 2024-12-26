using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Toolbox.Filters;

[AttributeUsage(AttributeTargets.All)]
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        var exception = context.Exception;
        var problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,

            Title = !string.IsNullOrEmpty(exception?.Message) ? exception?.Message : "An error occured while processing your request",
            Detail = exception?.Message + exception?.StackTrace?.ToString()
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
        base.OnException(context);
    }
}
