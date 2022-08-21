using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace notes_api.Filters
{
   public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var publicException = context.Exception as ApiPublicException;

            //use public exceptions to hide implementation details
            if(publicException != null)
            {
                context.HttpContext.Response.StatusCode = (int)publicException.StatusCode;
                context.Result = new JsonResult(new { message = publicException.PublicMessage });
            } else
            {
                //Would depend on the target audience
                context.Result = new JsonResult(new { message = "Unknown error!" });
            }
            return Task.CompletedTask;
        }
    }
}
