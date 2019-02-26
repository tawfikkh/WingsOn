using log4net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WingsOn.Api.Filters
{
    public class AuditFilterAttribute : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AuditFilterAttribute));

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Logger.Info($"{actionContext.Request.Method} {actionContext.Request.RequestUri.PathAndQuery}");
            base.OnActionExecuting(actionContext);
        }
    }
}