﻿using Microsoft.AspNetCore.Mvc.Filters;

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
        Console.WriteLine($"OnActionExecuting - {_name}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"OnActionExecuted - {_name}");
    }

    public int Order { get; set; }
}