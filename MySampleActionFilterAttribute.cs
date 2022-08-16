using Microsoft.AspNetCore.Mvc.Filters;

namespace filters;

public class MySampleActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
{
    private readonly string _name;
    public MySampleActionFilterAttribute(string name, int order = 0)
    {
        _name = name;
        Order = order;
    }
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var route = context.RouteData;
        Console.WriteLine($"Action Filter - Before - {_name} {Order}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Action Filter - After - {_name} {Order}");
    }

    public int Order { get; set; }
}