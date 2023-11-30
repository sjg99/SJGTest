using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Filters
{
    public class HttpExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is CustomException exception)
                {
                    context.Result = new JsonResult(ErrorModel.Of(exception.Message)) { StatusCode = exception.Status };
                }
                else
                {
                    context.Result = new JsonResult(ErrorModel.Of("Unexpected Error: " + context.Exception.Message)) { StatusCode = 500 };
                }
                context.ExceptionHandled = true;
            }
        }
    }
}
