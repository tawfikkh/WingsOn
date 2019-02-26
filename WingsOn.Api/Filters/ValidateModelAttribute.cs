using log4net;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using WingsOn.Api.DTOs;
using WingsOn.Api.Helpers;

namespace WingsOn.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ValidateModelAttribute));

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var modelState = actionContext.ModelState;

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, ValidationHelper.GenerateApiError(modelState));

                Logger.Warn("model failed validation\n" + JsonConvert.SerializeObject(actionContext.ModelState));
            }
        }
    }
}