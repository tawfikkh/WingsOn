using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;
using WingsOn.Api.DTOs;

namespace WingsOn.Api.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(CustomExceptionFilterAttribute));

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;

            var errorObj = new ApiError();
            PopulateErrorObj(exception, errorObj, new List<ApiError>());

            actionExecutedContext.Response =
                actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, errorObj);

            Logger.Error("unhandled error occurred", exception);

            base.OnException(actionExecutedContext);
        }

        private void PopulateErrorObj(Exception exception, ApiError obj, IList<ApiError> processed)
        {
            // protect against cyclic references
            if (processed.Contains(obj)) return;

            obj.Message = exception.Message;
            obj.Target = exception.TargetSite.Name;
            obj.Code = exception.GetType().Namespace;

            // mark object as processed
            processed.Add(obj);

            if (exception.InnerException != null)
            {
                obj.Erorr = new ApiError();
                PopulateErrorObj(exception.InnerException, obj.Erorr, processed);
            }
        }
    }
}