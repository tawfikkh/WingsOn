using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WingsOn.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                    actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
    }
}