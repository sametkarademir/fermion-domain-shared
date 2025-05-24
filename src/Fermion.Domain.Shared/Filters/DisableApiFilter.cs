using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fermion.Domain.Shared.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DisableApiFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        context.Result = new EmptyResult();
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}