using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspBootstrap.Filters
{
    public class ValidateInputFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid) 
            {
                context.Result = new ObjectResult("Not Valid!") { StatusCode = 400 };
            }
        }
    }
}
