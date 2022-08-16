using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace filters;

public class MySampleResourceFilterAttribute : Attribute, IResourceFilter
{
    private readonly string _name;

    public MySampleResourceFilterAttribute(string name)
    {
        _name = name;
    }
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Console.WriteLine($"Resource Filter - Before - {_name}");
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        var queryData = context.RouteData;
        if(queryData.Values.Keys.Contains("id"))
        {
            var idValue = queryData.Values["id"].ToString();
            if(int.TryParse(idValue, out var id))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new ObjectResult(new { Error = "Id should be greather or equal to " });
            }
        }


        //Console.WriteLine($"Resource Filter - After - {_name}");
    }
}