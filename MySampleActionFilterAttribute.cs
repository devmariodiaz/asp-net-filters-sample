﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace filters;

public class MySampleActionFilterAttribute : Attribute, IActionFilter
{
    private readonly string _name;
    public MySampleActionFilterAttribute(string name)
    {
        _name = name;
    }
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"OnActionExecuting - {_name}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"OnActionExecuted - {_name}");
    }
}