using Microsoft.AspNetCore.Mvc.Filters;

namespace filters;

public class MySampleAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
{
    private readonly string _name;
    public MySampleAsyncActionFilterAttribute(string name)
    {
        _name = name;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine($"Action Filter - Before Async - {_name}");
        await next();
        Console.WriteLine($"Action Filter - After Async - {_name}");
    }
}